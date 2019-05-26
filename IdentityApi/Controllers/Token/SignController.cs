using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quorum.Domain.IdentityCore.Interfaces.Services;
using Quorum.IdentityApi.Controllers.Token.ResultModels;
using Quorum.IdentityApi.Controllers.Token.ViewModels;

namespace Quorum.IdentityApi.Controllers.Token
{
	[Route("identity/sign")]
	public class SignController : Controller
	{
		private readonly ISignService _signService;
		private readonly IJwtGenerationService _jwtService;

		public SignController(ISignService signService, IJwtGenerationService jwtService)
		{
			_signService = signService;
			_jwtService = jwtService;
		}

		[HttpPost("in")]
		public async Task<ActionResult<SignInResultModel>> SignIn([FromBody] SignInViewModel viewModel)
		{
			var user = await _signService.SignInAsync(viewModel.Email, viewModel.Password);

			if (user == null)
			{
				return Forbid();
			}

			return new SignInResultModel { Token = _jwtService.GenerateToken(user) };
		}
	}
}