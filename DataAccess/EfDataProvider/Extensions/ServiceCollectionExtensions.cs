using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.Ef.Repositories;

namespace Quorum.DataAccess.Ef.Extensions
{
	public static class ServiceCollectionExtensionsExtensions
	{
		public static void AddEfDataAccess(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<EfDataAccessContext>(o => { o.UseNpgsql(connectionString); });

			services.AddScoped<ITestRepository, TestRepository>()
			        .AddScoped<IChallengedTestRepository, ChallengedTestRepository>();
		}
	}
}