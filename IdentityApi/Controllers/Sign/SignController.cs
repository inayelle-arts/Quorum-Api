using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quorum.Domain.IdentityCore.Infrastructure.Commands.SignIn;
using Quorum.Domain.IdentityCore.Interfaces.Services;
using Quorum.IdentityApi.Controllers.Sign.ResultModels;

namespace Quorum.IdentityApi.Controllers.Sign
{
	[Route("identity/sign")]
	public class SignController : Controller
	{
		private readonly IMediator             _mediator;
		private readonly IJwtGenerationService _jwtService;

		public SignController(IJwtGenerationService jwtService, IMediator mediator)
		{
			_jwtService = jwtService;
			_mediator   = mediator;
		}

		[HttpPost("in")]
		public async Task<ActionResult<SignInResultModel>> SignIn([FromBody] SignInRequest request)
		{
			var user = await _mediator.Send(request);

			if (user == null)
			{
				return BadRequest(request.Email);
			}

			return new SignInResultModel { Token = _jwtService.GenerateToken(user) };
		}
	}
}