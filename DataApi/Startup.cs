using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quorum.BusinessCore.Models.Challenge;
using Quorum.DataApi.Enums;
using Quorum.DataApi.Extensions;
using Quorum.Shared.Auxiliary;
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
			services.AddSettings(Configuration);

			services.AddPasswordHasher();
			services.AddModels(typeof(ChallengeModel).Assembly);
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddDataProvider(DataProvider.EntityFramework, Configuration.GetConnectionString("Quorum_EF"));

			services.AddJwtAuthentication(Configuration);
			services.AddApiMvc();
		}

		public override void Configure(IApplicationBuilder app)
		{
			app.UseAuthentication();

			app.UseMvc();
		}
	}
}