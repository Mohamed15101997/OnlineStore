namespace OnlineStore.APIs.Attributes
{
	public class CashedAttribute : Attribute, IAsyncActionFilter
	{
		private readonly int _expireTime;

		public CashedAttribute(int expireTime)
		{
			_expireTime = expireTime;
		}
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var casheService = context.HttpContext.RequestServices.GetRequiredService<ICashService>();

			var cashKey = GenerateCashKeyFromRequest(context.HttpContext.Request);

			var cashResponse = await  casheService.GetCashKeyAsync(cashKey);

			if (!string.IsNullOrEmpty(cashResponse)) 
			{
				var contentResult = new ContentResult()
				{
					Content = cashResponse , 
					ContentType = "application/json" , 
					StatusCode = 200
				};

				context.Result = contentResult;
				return;
			}

			var exexutedContext = await next();

			if(exexutedContext.Result is OkObjectResult response) 
			{
				await casheService.SetCashKeyAsync(cashKey,response.Value,TimeSpan.FromSeconds(_expireTime));
			}
		}
		private string GenerateCashKeyFromRequest(HttpRequest request) 
		{
			var cashKey = new StringBuilder();

			cashKey.Append($"{request.Path}");

			foreach (var (key,value) in request.Query.OrderBy(x => x.Key))
			{
				cashKey.Append($"|{key}-{value}");
			}

			return cashKey.ToString();
		}
	}
}
