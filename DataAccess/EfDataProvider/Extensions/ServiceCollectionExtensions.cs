using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.EfDataProvider.Repositories;

namespace Quorum.DataAccess.EfDataProvider.Extensions
{
	public static class ServiceCollectionExtensionsExtensions
	{
		public static void AddEfDataAccess(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<EfDataContext>(o => { o.UseNpgsql(connectionString); });

			services.AddTransient<ITestRepository, TestRepository>()
			        .AddTransient<IChallengedTestRepository, ChallengedTestRepository>()
			        .AddTransient<IUserRepository, UserRepository>();
		}
	}
}