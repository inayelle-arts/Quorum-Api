using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Quorum.DataApi.Enums;
using Quorum.DataApi.Interfaces;
using Quorum.DataApi.Services.Jwt;
using Quorum.DataApi.Settings;
using Quorum.DataProviders.AdoDataProvider.Extensions;
using Quorum.DataProviders.EfDataProvider.Extensions;
using Quorum.Entities.Domain;
using Quorum.Shared.Filters;

namespace Quorum.DataApi.Extensions
{
	internal static class ServiceCollectionExtensions
	{
		public static void AddPasswordHasher(this IServiceCollection services)
		{
			services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
		}

		public static void AddApiMvc(this IServiceCollection services)
		{
			services.AddMvc(options => { options.Filters.Add<ModelValidationFilter>(); })
					.AddJsonOptions(options =>
											options.SerializerSettings
												   .ReferenceLoopHandling =
													Newtonsoft.Json.ReferenceLoopHandling.Ignore);
		}

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

			services.AddSingleton<IAuthenticationService, JwtAuthenticationService>()
					.AddSingleton<JwtSecurityTokenHandler>();
		}

		[Obsolete("No need in CORS due to nginx gateway")]
		public static void AddClientCors(this IServiceCollection services, IConfiguration configuration)
		{
			var policy = new CorsPolicyBuilder()
						.WithOrigins(configuration["Cors:Client:Host"])
						.AllowAnyHeader()
						.AllowAnyMethod()
						.Build();

			services.AddCors(cors => cors.AddPolicy("Client", policy));
		}

		public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
		{
			var jwtSettings = new JwtSettings();

			configuration.Bind("Authentication", jwtSettings);

			services.AddSingleton(jwtSettings);
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