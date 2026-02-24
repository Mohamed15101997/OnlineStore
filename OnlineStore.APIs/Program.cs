namespace OnlineStore.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDependencyInjection(builder.Configuration);
		
			var app = builder.Build();

            await app.ConfigureMiddlewareAsync();

            app.Run();
        }
    }
}
