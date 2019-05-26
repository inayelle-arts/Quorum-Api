using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Quorum.Shared.Extensions
{
	public static class ApplicationBuilderExtensionsExtensions
	{
		public static void EnsureMigrated<TContext>(this IApplicationBuilder app) where TContext : DbContext
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<TContext>();
				
				context.Database.Migrate();
			}
		}
	}
}