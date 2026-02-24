using Microsoft.AspNetCore.Identity;
using OnlineStore.Core.Entities.Identity;
using OnlineStore.Repository.Data.Contexts;

namespace OnlineStore.Repository.Identity
{
	public static class StoreIdentityDbContextSeed
	{
		public async static Task SeedAsync(UserManager<ApplicationUser> _userManager) 
		{
			if(_userManager.Users.Count() == 0) 
			{
				var user = new ApplicationUser
				{
					Email = "mohamed.hosni.thabet@gmail.com",
					DisplayName = "Mohamed Hosni",
					UserName = "admin",
					PhoneNumber = "1234567890",
					Adress = new Address
					{
						FirstName = "Mohamed",
						LastName = "Hosni",
						City = "Giza",
						Country = "Egypt",
						Street = "St1"
					}
				};
				await _userManager.CreateAsync(user, "P@ssw0rd");
			}
		}
	}
}
