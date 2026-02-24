using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Core.Entities.Identity;
using OnlineStore.Core.IServices.Token;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineStore.Service.Services.Token
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task<string> GenerateTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Email,user.Email),
				new Claim(ClaimTypes.GivenName,user.DisplayName),
				new Claim(ClaimTypes.MobilePhone,user.PhoneNumber)
			};

			var userRoles = await userManager.GetRolesAsync(user);

			foreach (var role in userRoles)
			{
				claims.Add(new Claim(ClaimTypes.Role,role));
			}

			var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

			var token = new JwtSecurityToken
				( issuer : _configuration["JWT:Issuer"],
				audience : _configuration["JWT:Audience"],
				expires : DateTime.Now.AddHours(double.Parse(_configuration["JWT:DurationInHours"])),
				claims : claims ,
				signingCredentials : new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
				
				);

			return  new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
