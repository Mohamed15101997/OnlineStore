namespace OnlineStore.APIs.Errors
{
	public class ApiResponseError
	{
		public int StatusCode { get; set; }
		public string? Message { get; set; }

		public ApiResponseError(int statusCode, string? message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatusCode(statusCode);
		}
		private string? GetDefaultMessageForStatusCode(int statusCode) 
		{
			var message = statusCode switch 
			{
				400 => "Bad Request",
				401 => "Un Authorize",
				404 => "Resourse Not Found",
				500 => "Server Error",
				_ => null
			};

			return message;
		}
	}
}
