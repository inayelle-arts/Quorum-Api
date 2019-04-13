using Microsoft.AspNetCore.Builder;

namespace Quorum.Api.Extensions
{
	internal static class ApplicationBuilderExtensionsExtensions
	{
		public static void UseAngularCors(this IApplicationBuilder app)
		{
			app.UseCors("Angular");
		}
	}
}