using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quorum.DataProviders.IdentityDataProvider.Extensions;
using StartupBase = Quorum.Shared.Base.StartupBase;

namespace Quorum.IdentityApi
{
	public class Startup : StartupBase
	{
		public Startup(IHostingEnvironment environment) : base(environment)
		{
		}

		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentityDataProvider(Configuration.GetConnectionString("Quorum_Identity"));

			services.AddMvc();
		}

		public override void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}
	}
}