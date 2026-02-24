namespace OnlineStore.APIs.Helper
{
	public static class ConfigureMiddleware
	{
		public static async Task<WebApplication> ConfigureMiddlewareAsync(this WebApplication app) 
		{
			await app.AddMigrateDataBase();
			app.AddUserDefindMiddleware();
			app.AddConfigureHTTPRequestPipeline();
			app.AddUseStatusCodePagesWithReExecuteMiddleware();
			app.AddUseStaticFilesMiddleware();
			app.AddUseHttpsRedirectionMiddleware();
			app.AddUseAuthenticationMiddleware();
			app.AddUseAuthorizationMiddleware();
			app.AddMapControllersMiddleware();

			return app;
		}
		private static async Task<WebApplication> AddMigrateDataBase(this WebApplication app) 
		{
			var scope = app.Services.CreateScope(); // Container Have all Service Work with LifeTime Scope

			var services = scope.ServiceProvider; // All Service 

			var context = services.GetRequiredService<StoreDbContext>();
			var identityContext = services.GetRequiredService<StoreIdentityDbContext>();
			var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

			var loggerFactory = services.GetRequiredService<ILoggerFactory>();

			try
			{
				await context.Database.MigrateAsync();
				await StoreDbContextSeed.SeedAsync(context);
				await identityContext.Database.MigrateAsync();
				await StoreIdentityDbContextSeed.SeedAsync(userManager);

			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "There Are Problem During Apply Migrate");
			}
			return app;
		}
		private static WebApplication AddUserDefindMiddleware(this WebApplication app)
		{
			app.UseMiddleware<ExceptionMiddleware>();

			return app;
		}
		private static WebApplication AddConfigureHTTPRequestPipeline(this WebApplication app)
		{
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			return app;
		}
		private static WebApplication AddUseStatusCodePagesWithReExecuteMiddleware(this WebApplication app)
		{
			app.UseStatusCodePagesWithReExecute("/error/{0}"); // To Redirect NotFound EndPoint

			return app;
		}
		private static WebApplication AddUseStaticFilesMiddleware(this WebApplication app)
		{
			app.UseStaticFiles(); // To Static Files [Images , Html]

			return app;
		}
		private static WebApplication AddUseHttpsRedirectionMiddleware(this WebApplication app)
		{
			app.UseHttpsRedirection();

			return app;
		}
		private static WebApplication AddUseAuthenticationMiddleware(this WebApplication app)
		{
			app.UseAuthentication();

			return app;
		}
		private static WebApplication AddUseAuthorizationMiddleware(this WebApplication app)
		{
			app.UseAuthorization();

			return app;
		}
		private static WebApplication AddMapControllersMiddleware(this WebApplication app)
		{
			app.MapControllers();

			return app;
		}
	}
}
