using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client.Core.DependencyInjection;

namespace Quorum.IdentityApi.Base
{
	internal abstract class AsyncMessageHandlerBase<TPayload> : IAsyncMessageHandler
	{
		public Task Handle(string message, string routingKey)
		{
			var payload = JsonConvert.DeserializeObject<TPayload>(message);

			return Handle(payload);
		}

		protected abstract Task Handle(TPayload payload);
	}
}