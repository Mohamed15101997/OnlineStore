using OnlineStore.Core.Dtos.Auth;
using System.Security.Claims;

namespace OnlineStore.Core.IServices.Auth
{
	public interface IUserService
	{
		Task<UserDto> LoginAsync(LoginDto dto);
		Task<UserDto> RegisterAsync(RegisterDto dto);
		Task<bool> CheckEmailIsExistAsync(string email);
		Task<CurrentUserDto> CurrentUser(ClaimsPrincipal User);
	}
}
