using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Quorum.Shared.Extensions
{
	public static class HostingEnvironmentExtensions
	{
		public const string ConfigurationsDirectory = "Configurations";

		public static IConfiguration GetConfiguration(this IHostingEnvironment environment)
		{
			var configDir = Path.Combine(environment.ContentRootPath, ConfigurationsDirectory);

			var environmentName = environment.EnvironmentName.ToLowerInvariant();

			return new ConfigurationBuilder()
			       .SetBasePath(configDir)
			       .AddJsonFile("app.json", false, true)
			       .AddJsonFile($"app.{environmentName}.json", true, true)
			       .Build();
		}
	}
}