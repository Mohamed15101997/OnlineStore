using AutoMapper;
using Microsoft.Extensions.Configuration;
using OnlineStore.Core.Dtos.Products;
using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Mapping.Products
{
	public class PictureUrlResolver : IValueResolver<Product, ProductDto, string>
	{
		private readonly IConfiguration _configuration;

		public PictureUrlResolver(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.PictureUrl))
				return $"{_configuration["BASEURL"]}{source.PictureUrl}";
			return string.Empty;
		}
	}
}
