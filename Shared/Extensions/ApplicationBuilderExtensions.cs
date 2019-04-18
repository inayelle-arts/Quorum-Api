using Microsoft.AspNetCore.Builder;

namespace Quorum.Shared.Extensions
{
	public static class ApplicationBuilderExtensionsExtensions
	{
		public static void UseClientCors(this IApplicationBuilder app)
		{
			app.UseCors("Client");
		}
	}
}