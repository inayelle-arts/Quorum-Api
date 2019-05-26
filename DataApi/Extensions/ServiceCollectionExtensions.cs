using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Quorum.DataApi.Enums;
using Quorum.DataProviders.AdoDataProvider.Extensions;
using Quorum.DataProviders.EfDataProvider.Extensions;
using RabbitMQ.Client.Core.DependencyInjection;

namespace Quorum.DataApi.Extensions
{
	internal static class ServiceCollectionExtensions
	{
		public static void AddDataProvider(this IServiceCollection services,
										   DataProvider            provider,
										   string                  connectionString
		)
		{
			switch (provider)
			{
				case DataProvider.EntityFramework:
				{
					services.AddEfDataAccess(connectionString);
					break;
				}

				case DataProvider.AdoNet:
				{
					services.AddAdoDataAccess(connectionString);
					break;
				}

				default:
				{
					throw new NotImplementedException($"Unimplemented {provider} provider");
				}
			}
		}

		public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					 {
						 options.RequireHttpsMetadata      = false;
						 options.TokenValidationParameters = configuration.GetValidationParameters();
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
		}

		private static TokenValidationParameters GetValidationParameters(this IConfiguration configuration)
		{
			var signKeyBytes = Encoding.UTF8.GetBytes(configuration["Authentication:SignKey"]);
			var signKey      = new SymmetricSecurityKey(signKeyBytes);

			return new TokenValidationParameters
			{
				ValidateIssuer           = true,
				ValidateAudience         = true,
				ValidateLifetime         = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer              = configuration["Authentication:Issuer"],
				ValidAudience            = configuration["Authentication:Audience"],
				IssuerSigningKey         = signKey
			};
		}
	}
}