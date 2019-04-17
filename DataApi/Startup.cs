using AspNetCore.RouteAnalyzer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quorum.DataApi.Enums;
using Quorum.DataApi.Extensions;
using Quorum.Shared.Auxiliary;

namespace Quorum.DataApi
{
	internal sealed class Startup
	{
		public IHostingEnvironment Environment   { get; }
		public IConfiguration      Configuration { get; }

		public Startup(IHostingEnvironment environment)
		{
			Environment   = Require.NotNull(environment, nameof(environment));
			Configuration = Environment.GetConfiguration();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRouteAnalyzer();

			services.AddSingleton(Configuration);

			services.AddAngularCors(Configuration);

			services.AddModels();

			services.AddAutoMapper();

			services.AddDataProvider(DataProvider.EntityFramework, Configuration.GetConnectionString("Quorum_EF"));

			services.AddApiMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseAngularCors();

			app.UseMvc(router => { router.MapRouteAnalyzer("/routes"); });
		}
	}
}