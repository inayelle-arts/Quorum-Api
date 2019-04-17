using Microsoft.AspNetCore.Builder;

namespace Quorum.DataApi.Extensions
{
	internal static class ApplicationBuilderExtensionsExtensions
	{
		public static void UseAngularCors(this IApplicationBuilder app)
		{
			app.UseCors("Angular");
		}
	}
}