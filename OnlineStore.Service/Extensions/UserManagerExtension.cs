using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Identity;
using System.Security.Claims;

namespace OnlineStore.Service.Extensions
{
	public static class UserManagerExtension
	{
		public static async Task<ApplicationUser> FindByEmailWithAdressAsync(this UserManager<ApplicationUser> userManager, ClaimsPrincipal User)
		{
			var userEmail = User.FindFirstValue(ClaimTypes.Email);

			//if (userEmail is null) return null;

			var user = await userManager.Users.Include(x => x.Adress).FirstOrDefaultAsync(x => x.Email == userEmail);

			return user;
		}
	}
}
