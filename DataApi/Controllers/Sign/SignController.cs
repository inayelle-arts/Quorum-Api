using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Interfaces.Services;
using Quorum.DataApi.Controllers.Sign.PayloadModels;
using Quorum.DataApi.Controllers.Sign.ViewModels;
using Quorum.DataApi.Services.Identity;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Controllers.Sign
{
	[Route("api/sign")]
	public sealed class SignController : Controller
	{
		private readonly IdentityService _identityService;
		private readonly ISignUpService  _signUpService;

		public SignController(IdentityService identityService, ISignUpService signUpService)
		{
			_identityService = identityService;
			_signUpService   = signUpService;
		}

		[HttpPost("up")]
		public async Task<ActionResult> SignUp([FromBody] SignUpViewModel signUpModel)
		{
			var user = await _signUpService.SignUpAsync(signUpModel.MapTo<User>());

			if (user == null)
			{
				return Conflict();
			}

			var payload = new CreateUserPayload
			{
				DomainId = user.Id,
				Email    = user.Email,
				Role     = signUpModel.Role,
				Password = signUpModel.Password
			};
			
			await _identityService.CreateUserAsync(payload);

			return Ok();
		}
	}
}