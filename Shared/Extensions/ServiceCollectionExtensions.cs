using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Quorum.Shared.Filters;

namespace Quorum.Shared.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddAutoMapper(this IServiceCollection services, Assembly assembly)
		{
			Mapper.Initialize(config => { config.AddProfiles(assembly); });
		}

		public static void AddApiMvc(this IServiceCollection services)
		{
			services.AddMvc(options => { options.Filters.Add<ModelValidationFilter>(); })
					.AddJsonOptions(options =>
											options.SerializerSettings
												   .ReferenceLoopHandling =
													Newtonsoft.Json.ReferenceLoopHandling.Ignore);
		}
	}
}