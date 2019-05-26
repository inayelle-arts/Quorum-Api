using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quorum.Domain.IdentityCore.Services.JwtAuthentication;
using Quorum.IdentityApi.Handlers.CreateUser;
using RabbitMQ.Client.Core.DependencyInjection;

namespace Quorum.IdentityApi.Extensions
{
	internal static class ServiceCollectionExtensions
	{
		public static void AddJwtSettings(this IServiceCollection services)
		{
			services.AddSingleton(provider =>
			{
				var settings = new JwtSettings();

				var configuration = provider.GetRequiredService<IConfiguration>();
				
				configuration.Bind("Authentication", settings);

				return settings;
			});
		}
		
		public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
		{
			var rabbitMqConfig  = configuration.GetSection("RabbitMQ");
			var exchangesConfig = configuration.GetSection("RabbitMQ:Exchanges");

			services.AddRabbitMqClient(rabbitMqConfig);

			foreach (var exchangeConfig in exchangesConfig.GetChildren())
			{
				services.AddExchange(exchangeConfig.Key, exchangeConfig);
			}

			services.AddAsyncMessageHandlerTransient<CreateUserHandler>("sign.up");
		}
	}
}