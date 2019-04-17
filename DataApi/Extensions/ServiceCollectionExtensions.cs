using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quorum.BusinessCore.Models.Challenge;
using Quorum.DataAccess.Ef.Extensions;
using Quorum.DataApi.Enums;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Extensions
{
	internal static class ServiceCollectionExtensions
	{
		private const string ModelPostfix = "Model";

		public static void AddAngularCors(this IServiceCollection services, IConfiguration configuration)
		{
			var policy = new CorsPolicyBuilder()
			             .WithOrigins(configuration["Cors:Angular:Host"])
			             .AllowAnyHeader()
			             .AllowAnyMethod()
			             .Build();

			services.AddCors(cors => cors.AddPolicy("Angular", policy));
		}

		public static void AddApiMvc(this IServiceCollection services)
		{
			services.AddMvc().AddJsonOptions(options =>
					options.SerializerSettings
					       .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
		}

		public static void AddAutoMapper(this IServiceCollection services)
		{
			Mapper.Initialize(config => { config.AddProfiles(Assembly.GetExecutingAssembly()); });

			var mapper = new Mapper(Mapper.Configuration);

			services.AddSingleton<IMapper>(mapper);

			EntityExtensions.Mapper = mapper;
		}

		public static void AddModels(this IServiceCollection services)
		{
			var modelTypes = Assembly.GetAssembly(typeof(ChallengeModel))
			                         .GetTypesWithPostfix(ModelPostfix);

			foreach (var modelType in modelTypes)
			{
				services.AddScoped(modelType);
			}
		}

		public static void AddDataProvider(this IServiceCollection services,
		                                   DataProvider            provider,
		                                   string                  connectionString)
		{
			switch (provider)
			{
				case DataProvider.EntityFramework:
				{
					services.AddEfDataAccess(connectionString);
					break;
				}
				default:
				{
					throw new NotImplementedException($"Unimplemented {provider} provider");
				}
			}
		}
	}
}