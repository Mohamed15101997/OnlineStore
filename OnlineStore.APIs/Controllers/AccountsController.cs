namespace OnlineStore.APIs.Controllers
{
	public class AccountsController : OnlineStoreController
	{
		private readonly IUserService _userService;

		public AccountsController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpPost("Login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto dto) 
		{
			var user = await _userService.LoginAsync(dto);

			if (user is null) 
				return Unauthorized(new ApiResponseError(StatusCodes.Status401Unauthorized , "Email Or Password Invalid"));

			return Ok(user);
		}
		[HttpPost("Register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
		{
			var user = await _userService.RegisterAsync(dto);

			if (user is null)
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest, "Invalid Registertion"));

			return Ok(user);
		}

		[HttpGet("GetCurrentUser")]
		public async Task<ActionResult<CurrentUserDto>> GetCurrentUser()
		{
			var user = await _userService.CurrentUser(User);

			if (user is null)
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest, "You Should Login"));

			return Ok(user);
		}

	}
}
