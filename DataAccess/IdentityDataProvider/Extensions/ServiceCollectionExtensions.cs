using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quorum.Entities;

namespace Quorum.DataAccess.IdentityDataProvider.Extensions
{
	public static class ServiceCollectionExtensionsExtensions
	{
		public static void AddIdentityDataProvider(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<IdentityDataContext>(o => o.UseNpgsql(connectionString));

			services.AddIdentity<User, IdentityRole>()
			        .AddEntityFrameworkStores<IdentityDataContext>();
		}
	}
}