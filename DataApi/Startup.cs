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

namespace Quorum.DataApi
{
	internal sealed class Startup
	{
		public IHostingEnvironment Environment   { get; }
		public IConfiguration      Configuration { get; }

		public Startup(IHostingEnvironment environment)
		{
			Environment   = Require.NotNull(environment, nameof(environment));
			Configuration = environment.GetConfiguration();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(Configuration);

			services.AddModels(typeof(ChallengeModel).Assembly);
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddDataProvider(DataProvider.EntityFramework, Configuration.GetConnectionString("Quorum_EF"));
			//services.AddDataProvider(DataProvider.AdoNet, Configuration.GetConnectionString("Quorum_ADO"));

			services.AddClientCors(Configuration);

			services.AddJwtAuthentication(Configuration);
			services.AddApiMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseClientCors();

			app.UseAuthentication();

			app.UseMvc();
		}
	}
}