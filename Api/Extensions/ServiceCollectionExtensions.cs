using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Quorum.Api.Extensions
{
	internal static class ServiceCollectionExtensionsExtensions
	{
		public static void AddAngularCors(this IServiceCollection services, IConfiguration configuration)
		{
			var policy = new CorsPolicyBuilder()
			             .WithOrigins(configuration["Cors:Angular:Host"])
			             .AllowAnyHeader()
			             .AllowAnyMethod()
			             .Build();

			services.AddCors(cors => cors.AddPolicy("Angular", policy));
		}
	}
}