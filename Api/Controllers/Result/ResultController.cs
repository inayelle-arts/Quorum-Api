using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quorum.Api.Controllers.Result.ResultModels;
using Quorum.Api.Extensions;
using Quorum.BusinessCore.Interfaces;

namespace Quorum.Api.Controllers.Result
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
		public async Task<ActionResult<PassedTestResultModel>> Get(int id)
		{
			var challengedTest = await _challengedTests.GetAsync(id);

			if (challengedTest == null)
			{
				return NotFound(id);
			}

			return challengedTest.To<PassedTestResultModel>();
		}
	}
}