using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quorum.Shared.Auxiliary;
using Quorum.Shared.Extensions;

namespace Quorum.Shared.Base
{
	public abstract class StartupBase
	{
		public IHostingEnvironment Environment   { get; }
		public IConfiguration      Configuration { get; }

		protected StartupBase(IHostingEnvironment environment)
		{
			Environment   = Require.NotNull(environment, nameof(environment));
			Configuration = Environment.GetConfiguration();
		}

		public abstract void ConfigureServices(IServiceCollection services);

		public abstract void Configure(IApplicationBuilder app);
	}
}