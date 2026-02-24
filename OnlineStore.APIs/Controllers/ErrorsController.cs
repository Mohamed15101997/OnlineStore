namespace OnlineStore.APIs.Controllers
{
	[Route("error/{code}")]
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorsController : ControllerBase
	{
		public IActionResult Error(int code) 
		{
			return NotFound(new ApiResponseError(StatusCodes.Status404NotFound,"Not Found Page !"));
		}
	}
}
