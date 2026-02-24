using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Core.Entities.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string DisplayName { get; set; }
		public Address Adress { get; set; }
	}
}
