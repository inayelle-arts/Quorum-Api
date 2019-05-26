using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quorum.Domain.IdentityCore.Interfaces.Services;
using Quorum.IdentityApi.Base;

namespace Quorum.IdentityApi.Handlers.CreateUser
{
	internal sealed class CreateUserHandler : AsyncMessageHandlerBase<CreateUserPayload>, IDisposable
	{
		private readonly IServiceScope _serviceScope;
		private readonly ISignService  _signService;

		public CreateUserHandler(IServiceProvider serviceProvider)
		{
			_serviceScope = serviceProvider.CreateScope();
			_signService  = _serviceScope.ServiceProvider.GetRequiredService<ISignService>();
		}

		protected override async Task Handle(CreateUserPayload payload)
		{
			await _signService.SignUpAsync(payload.Email, payload.Password, payload.Role);
		}

		public void Dispose()
		{
			_serviceScope.Dispose();
		}
	}
}