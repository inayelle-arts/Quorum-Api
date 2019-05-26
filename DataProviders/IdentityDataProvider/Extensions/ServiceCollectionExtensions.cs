using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quorum.Entities;
using Quorum.Entities.Identity;

namespace Quorum.DataProviders.IdentityDataProvider.Extensions
{
	public static class ServiceCollectionExtensionsExtensions
	{
		public static void AddIdentityDataProvider(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<IdentityDataContext>(o => o.UseNpgsql(connectionString));

			services.AddIdentity<QuorumUser, IdentityRole>()
			        .AddEntityFrameworkStores<IdentityDataContext>();
		}
	}
}