
using FastEndpoints;
using FastEndpoints.Swagger;

namespace DemoAPi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Configure Web Behavior
			builder.Services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			builder.Services.AddFastEndpoints()
				.SwaggerDocument(o =>
				{
					o.ShortSchemaNames = true;
				});

			// Add services to the container.
			builder.Services.AddAuthorization();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();

			var app = builder.Build();

			app.UseFastEndpoints()
				.UseSwaggerGen(); // Includes AddFileServer and static files middleware

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.Run();
		}
	}
}
