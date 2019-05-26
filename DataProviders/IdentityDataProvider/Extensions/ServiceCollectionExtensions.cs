using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quorum.DataProviders.IdentityDataProvider.Repositories;
using Quorum.Domain.IdentityCore.Interfaces.Repositories;

namespace Quorum.DataProviders.IdentityDataProvider.Extensions
{
	public static class ServiceCollectionExtensionsExtensions
	{
		public static void AddIdentityDataProvider(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<IdentityDataContext>(o => o.UseNpgsql(connectionString));

			services.AddScoped<IQuorumUserRepository, QuorumUserRepository>();
		}
	}
}