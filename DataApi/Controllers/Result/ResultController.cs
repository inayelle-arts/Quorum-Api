using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Interfaces;
using Quorum.DataApi.Controllers.Result.ResultModels;
using Quorum.DataApi.Extensions;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Controllers.Result
{
	[Route("api/result")]
	public sealed class ResultController : Controller
	{
		private readonly IChallengedTestRepository _challengedTests;

		public ResultController(IChallengedTestRepository challengedTests)
		{
			_challengedTests = challengedTests;
		}
		
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<PassedTestResultModel>> Get(int id)
		{
			var challengedTest = await _challengedTests.GetByIdAsync(id);

			if (challengedTest == null)
			{
				return NotFound(id);
			}

			return challengedTest.To<PassedTestResultModel>();
		}
	}
}