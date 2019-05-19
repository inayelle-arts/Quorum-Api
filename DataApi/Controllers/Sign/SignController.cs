using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Models.Sign;
using Quorum.DataApi.Controllers.Sign.ResultModels;
using Quorum.DataApi.Controllers.Sign.ViewModels;
using Quorum.DataApi.Interfaces;
using Quorum.Entities.Domain;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Controllers.Sign
{
	[Route("api/sign")]
	public sealed class SignController : Controller
	{
		private readonly SignModel              _signModel;
		private readonly IAuthenticationService _authenticationService;

		public SignController(SignModel signModel, IAuthenticationService authenticationService)
		{
			_signModel             = signModel;
			_authenticationService = authenticationService;
		}

		[HttpPost("up")]
		public async Task<ActionResult<SignResultModel>> SignUp([FromBody] SignUpViewModel signUpModel)
		{
			var user = await _signModel.SignUp(signUpModel.MapTo<User>());

			if (user == null)
			{
				return NotFound(signUpModel);
			}

			var token = _authenticationService.GenerateToken(user);

			return Ok(new SignResultModel(token));
		}

		[HttpPost("in")]
		public async Task<ActionResult<SignResultModel>> SignIn([FromBody] SignInViewModel signInModel)
		{
			var user = await _signModel.SignIn(signInModel.MapTo<User>());

			if (user == null)
			{
				return NotFound(signInModel);
			}

			var token = _authenticationService.GenerateToken(user);

			return Ok(new SignResultModel(token));
		}
	}
}