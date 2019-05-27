using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quorum.DataProviders.IdentityDataProvider;
using Quorum.DataProviders.IdentityDataProvider.Extensions;
using Quorum.Domain.IdentityCore.Extensions;
using Quorum.IdentityApi.Extensions;
using Quorum.Shared.Extensions;
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
			services.AddSingleton(Configuration);
			
			services.AddIdentityDataProvider(Configuration.GetConnectionString("Quorum_Identity"));

			services.AddJwtSettings();
			
			services.AddIdentityCoreServices();
			
			services.AddRabbitMq(Configuration);
			
			services.AddApiMvc();
		}

		public override void Configure(IApplicationBuilder app)
		{
			app.EnsureMigrated<IdentityDataContext>();
			
			app.UseRabbitMq();
			
			app.UseMvc();
		}
	}
}