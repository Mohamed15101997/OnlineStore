using AutoMapper;
using Microsoft.Extensions.Configuration;
using OnlineStore.Core.Dtos.Products;
using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Mapping.Products
{
	public class ProductProfile : Profile
	{
		private readonly IConfiguration _configuration;

		public ProductProfile(IConfiguration configuration)
		{
			_configuration = configuration;
			MapEntity();
		}
		public void MapEntity() 
		{
			CreateMap<Product, ProductDto>()
				.ForMember(d => d.BrandName , options => options.MapFrom(s => s.Brand.Name))
				.ForMember(d => d.ProductTypeName , options => options.MapFrom(s => s.Type.Name))
				//.ForMember(d => d.PictureUrl , options => options.MapFrom(s => $"{_configuration["BASEURL"]}{s.PictureUrl}"));
				.ForMember(d => d.PictureUrl , options => options.MapFrom(new PictureUrlResolver(_configuration)));
		}
	}
}
