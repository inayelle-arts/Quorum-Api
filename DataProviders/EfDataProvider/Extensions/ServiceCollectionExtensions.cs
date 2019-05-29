using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.DataProviders.EfDataProvider.Repositories;

namespace Quorum.DataProviders.EfDataProvider.Extensions
{
	public static class ServiceCollectionExtensionsExtensions
	{
		public static void AddEfDataAccess(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<EfDataContext>(o => { o.UseNpgsql(connectionString); });

			services.AddScoped<ITestRepository, TestRepository>()
					.AddScoped<IChallengedTestRepository, ChallengedTestRepository>()
					.AddScoped<IUserRepository, UserRepository>();
		}
	}
}