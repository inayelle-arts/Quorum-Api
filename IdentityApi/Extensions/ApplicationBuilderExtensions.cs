using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection;

namespace Quorum.IdentityApi.Extensions
{
	internal static class ApplicationBuilderExtensions
	{
		public static void UseRabbitMq(this IApplicationBuilder app)
		{
			var queueService = app.ApplicationServices.GetRequiredService<IQueueService>();

			queueService.StartConsuming();
		}
	}
}