namespace OnlineStore.Core.Dtos.Auth
{
	public class CurrentUserDto
	{
		public string DisplayName { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public UserAdressDto Adress { get; set; }
	}
}
