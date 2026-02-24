namespace OnlineStore.APIs.Errors
{
	public class ApiValidationResponseError : ApiResponseError
	{
		public IEnumerable<string> Error { get; set; } = new List<string>();
		public ApiValidationResponseError() : base(400)
		{}
	}

}
