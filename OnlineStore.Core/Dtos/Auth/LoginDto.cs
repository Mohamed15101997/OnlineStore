using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Core.Dtos.Auth
{
	public class LoginDto
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password Is Required")]
		public string Password { get; set; }
	}
}
