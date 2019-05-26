using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Quorum.DataApi.Controllers.Sign.PayloadModels;
using Quorum.DataApi.Controllers.Sign.ViewModels;
using Quorum.Domain.Entities.Domain;
using RabbitMQ.Client.Core.DependencyInjection;

namespace Quorum.DataApi.Services.Identity
{
	public sealed class IdentityService
	{
		private readonly IQueueService _queueService;

		public IdentityService(IQueueService queueService)
		{
			_queueService = queueService;
		}

		public async Task CreateUserAsync(CreateUserPayload userPayload)
		{
			string json = JsonConvert.SerializeObject(userPayload);
			await _queueService.SendJsonAsync(json, "IdentityExchange", "sign.up");
		}
	}
}