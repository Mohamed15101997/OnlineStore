using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Core.Dtos.Auth;
using OnlineStore.Core.Entities.Identity;
using OnlineStore.Core.IServices.Auth;
using OnlineStore.Core.IServices.Token;
using OnlineStore.Service.Extensions;
using System.Security.Claims;

namespace OnlineStore.Service.Services.Auth
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ITokenService _tokenService;
		private readonly IMapper _mapper;

		public UserService(UserManager<ApplicationUser> userManager,ITokenService tokenService,IMapper mapper)
		{
			_userManager = userManager;
			_tokenService = tokenService;
			_mapper = mapper;
		}
		public async Task<UserDto> LoginAsync(LoginDto dto)
		{
			var user = await _userManager.FindByEmailAsync(dto.Email);
			if (user is null) return null;

			bool isSuccess = await _userManager.CheckPasswordAsync(user,dto.Password);

			if (!isSuccess) return null;

			return new UserDto
			{
				Email = user.Email,
				DisplayName = user.DisplayName , 
				Token = await _tokenService.GenerateTokenAsync(user, _userManager)
			};

		}
		public async Task<UserDto> RegisterAsync(RegisterDto dto)
		{
			bool emailIsExist = await CheckEmailIsExistAsync(dto.Email);

			if (emailIsExist) return null;

			var user = new ApplicationUser
			{
				Email = dto.Email,
				DisplayName = dto.DisplayName,
				PhoneNumber = dto.PhoneNumber,
				UserName = dto.Email.Split("@")[0]
			};

			var result = await _userManager.CreateAsync(user,dto.Password);

			if (!result.Succeeded) return null;

			return new UserDto
			{
				Email = user.Email,
				DisplayName = user.DisplayName,
				Token = await _tokenService.GenerateTokenAsync(user,_userManager)
			};
		}
		public async Task<bool> CheckEmailIsExistAsync(string email)
		{
			return await _userManager.FindByEmailAsync(email) is not null;
		}

		public async Task<CurrentUserDto> CurrentUser(ClaimsPrincipal User)
		{
			var user = await _userManager.FindByEmailWithAdressAsync(User);

			if (user is null) return null;

			var userMapped = _mapper.Map<CurrentUserDto>(user);

			return userMapped;
		}
	}
}
