using System;
using Microsoft.AspNetCore.Builder;

namespace Quorum.DataApi.Extensions
{
	internal static class ApplicationBuilderExtensions
	{
		[Obsolete("No need in CORS due to nginx gateway")]
		public static void UseClientCors(this IApplicationBuilder app)
		{
			app.UseCors("Client");
		}
	}
}