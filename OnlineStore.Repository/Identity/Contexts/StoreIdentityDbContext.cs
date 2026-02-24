using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Identity;

namespace OnlineStore.Repository.Identity.Contexts
{
	public class StoreIdentityDbContext : IdentityDbContext<ApplicationUser>
	{
		public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options) : base(options)
		{
			
		}
	}
}
