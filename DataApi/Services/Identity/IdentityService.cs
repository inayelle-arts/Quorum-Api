using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Quorum.DataApi.Controllers.Sign.ViewModels;
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

		public async Task CreateUserAsync(SignUpViewModel model)
		{
			string json = JsonConvert.SerializeObject(model);
			await _queueService.SendJsonAsync(json, "IdentityExchange", "sign.up");
		}
	}
}