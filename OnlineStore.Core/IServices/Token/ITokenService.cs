using Microsoft.AspNetCore.Identity;
using OnlineStore.Core.Entities.Identity;

namespace OnlineStore.Core.IServices.Token
{
	public interface ITokenService
	{
		Task<string> GenerateTokenAsync(ApplicationUser user , UserManager<ApplicationUser> userManager);
	}
}
