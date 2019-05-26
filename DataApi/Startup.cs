using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quorum.BusinessCore.Extensions;
using Quorum.DataApi.Enums;
using Quorum.DataApi.Extensions;
using Quorum.DataApi.Services.Identity;
using Quorum.DataProviders.EfDataProvider;
using Quorum.Shared.Extensions;
using StartupBase = Quorum.Shared.Base.StartupBase;

namespace Quorum.DataApi
{
	internal sealed class Startup : StartupBase
	{
		public Startup(IHostingEnvironment environment) : base(environment)
		{
		}

		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(Configuration);
			
			services.AddRabbitMq(Configuration);

			services.AddSingleton<IdentityService>();
			
			services.AddDomainServices();
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddDataProvider(DataProvider.EntityFramework, Configuration.GetConnectionString("Quorum_EF"));

			services.AddJwtAuthentication(Configuration);
			services.AddApiMvc();
		}

		public override void Configure(IApplicationBuilder app)
		{
			app.EnsureMigrated<EfDataContext>();
			
			app.UseAuthentication();
			
			app.UseMvc();
		}
	}
}