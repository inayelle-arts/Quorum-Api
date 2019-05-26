using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Quorum.Shared.Extensions
{
	public static class HostingEnvironmentExtensions
	{
		private const string ConfigurationsDirectory = "Configurations";
		private const string EnvironmentVarsPrefix   = "QUORUM_";

		public static IConfiguration GetConfiguration(this IHostingEnvironment environment)
		{
			string configDir = Path.Combine(environment.ContentRootPath, ConfigurationsDirectory);

			string environmentName = environment.EnvironmentName.ToLowerInvariant();

			return new ConfigurationBuilder()
				  .SetBasePath(configDir)
				  .AddJsonFile("app.json", false)
				  .AddJsonFile($"app.{environmentName}.json", true)
				  .AddEnvironmentVariables(EnvironmentVarsPrefix)
				  .Build();
		}
	}
}