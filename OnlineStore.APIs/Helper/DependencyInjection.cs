namespace OnlineStore.APIs.Helper
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDependencyInjection(this IServiceCollection service , IConfiguration configuration)
		{
			service.AddBuiltInService();
			service.AddSwaggerService();
			service.AddDbContextService(configuration);
			service.AddUserDefindService();
			service.AddAutoMapperService(configuration);
			service.ConfigureInvalidModelStateResponseFactory();
			service.AddRedisService(configuration);
			service.AddIdentityService();
			service.AddAuthenticationService(configuration);
			return service;
		}
		private static IServiceCollection AddBuiltInService(this IServiceCollection service) 
		{
			service.AddControllers();

			return service;
		}
		private static IServiceCollection AddSwaggerService(this IServiceCollection service)
		{
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			service.AddEndpointsApiExplorer();
			service.AddSwaggerGen();

			return service;
		}
		private static IServiceCollection AddDbContextService(this IServiceCollection service,IConfiguration configuration)
		{
			var connection = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection Failed");
			
			var identityConnection = configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Identity Connection Failed");

			service.AddDbContext<StoreDbContext>(options =>
			{
				options.UseSqlServer(connection);
			});

			service.AddDbContext<StoreIdentityDbContext>(options =>
			{
				options.UseSqlServer(identityConnection);
			});

			return service;
		}
		private static IServiceCollection AddUserDefindService(this IServiceCollection service)
		{
			// Inject Services
			service.AddScoped<IProductsService, ProductsService>();
			service.AddScoped<IBrandsService, BrandsService>();
			service.AddScoped<IProductTypesService, ProductTypesService>();
			service.AddScoped<IUnitOfWork, UnitOfWork>();
			service.AddScoped<IBasketRepository, BasketRepository>();
			service.AddScoped<IBasketService, BasketService>();
			service.AddScoped<ICashService, CashService>();
			service.AddScoped<ITokenService, TokenService>();
			service.AddScoped<IUserService, UserService>();
			service.AddScoped<IOrderService, OrderService>();
			service.AddScoped<IPaymentService, PaymentService>();

			return service;
		}
		private static IServiceCollection AddAutoMapperService(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddAutoMapper(m =>
			{
				m.AddProfile(new ProductProfile(configuration));
				m.AddProfile(new BrandProfile());
				m.AddProfile(new ProductTypeProfile());
				m.AddProfile(new BasketProfile());
				m.AddProfile(new AuthProfile());
			});

			return service;
		}
		private static IServiceCollection ConfigureInvalidModelStateResponseFactory(this IServiceCollection service)
		{
			service.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = (actionContext) =>
				{
					var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
											.SelectMany(p => p.Value.Errors)
											.Select(e => e.ErrorMessage)
											.ToArray();

					var response = new ApiValidationResponseError()
					{
						Error = errors
					};

					return new BadRequestObjectResult(response);
				};
			});

			return service;
		}
		private static IServiceCollection AddRedisService(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddSingleton<IConnectionMultiplexer>((serviceProvider) =>
			{
				var connection = configuration.GetConnectionString("Redis");
				return ConnectionMultiplexer.Connect(connection);
			});

			return service;
		}
		private static IServiceCollection AddIdentityService(this IServiceCollection service)
		{
			service.AddIdentity<ApplicationUser,IdentityRole>()
				.AddEntityFrameworkStores<StoreIdentityDbContext>();

			return service;
		}
		private static IServiceCollection AddAuthenticationService(this IServiceCollection service , IConfiguration configuration)
		{
			service.AddAuthentication(options => 
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options => 
			{
				options.TokenValidationParameters = new TokenValidationParameters 
				{
					ValidateIssuer = true , 
					ValidIssuer = configuration["JWT:Issuer"] , 
					ValidateAudience = true , 
					ValidAudience = configuration["JWT:Audience"],
					ValidateLifetime = true , 
					ValidateIssuerSigningKey = true ,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
				};
			});

			return service;
		}
	}
}
