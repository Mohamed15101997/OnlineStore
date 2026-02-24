using AutoMapper;
using OnlineStore.Core.Dtos.Auth;
using OnlineStore.Core.Entities.Identity;

namespace OnlineStore.Core.Mapping.Auth
{
	public class AuthProfile : Profile
	{
		public AuthProfile()
		{
			MapEntity();
		}
		public void MapEntity() 
		{
			CreateMap<ApplicationUser, CurrentUserDto>().ReverseMap();
			CreateMap<Address, UserAdressDto>()
				.ForMember(d => d.FullName , opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
				.ReverseMap();
		}
	}
}
