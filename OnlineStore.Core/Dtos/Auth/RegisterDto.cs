using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Core.Dtos.Auth
{
	public class RegisterDto
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress]
		public string Email { get; set; }
		[Required(ErrorMessage = "DisplayName Is Required")]
		public string DisplayName { get; set; }
		[Required(ErrorMessage = "PhoneNumber Is Required")]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "Password Is Required")]
		public string Password { get; set; }
	}
}
