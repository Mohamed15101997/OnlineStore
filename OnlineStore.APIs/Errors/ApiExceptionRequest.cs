namespace OnlineStore.APIs.Errors
{
	public class ApiExceptionRequest : ApiResponseError
	{
		public string? Details { get; set; }
		public ApiExceptionRequest(int statusCode , string? message = null, string? details = null) : base(statusCode,message)
		{
			Details = details;
		}
	}
}
