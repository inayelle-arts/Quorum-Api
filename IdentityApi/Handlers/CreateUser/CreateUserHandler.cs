using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quorum.Domain.IdentityCore.Infrastructure.Commands.SignUp;
using Quorum.Domain.IdentityCore.Interfaces.Services;
using Quorum.IdentityApi.Base;

namespace Quorum.IdentityApi.Handlers.CreateUser
{
	internal sealed class CreateUserHandler : AsyncMessageHandlerBase<SignUpRequest>, IDisposable
	{
		private readonly IServiceScope _serviceScope;
		private readonly IMediator     _mediator;

		public CreateUserHandler(IServiceProvider serviceProvider)
		{
			_serviceScope = serviceProvider.CreateScope();
			_mediator     = _serviceScope.ServiceProvider.GetRequiredService<IMediator>();
		}

		protected override Task Handle(SignUpRequest request)
		{
			return _mediator.Send(request);
		}

		public void Dispose()
		{
			_serviceScope.Dispose();
		}
	}
}