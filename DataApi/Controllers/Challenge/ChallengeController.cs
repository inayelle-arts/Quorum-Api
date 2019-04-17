using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Entities;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Models.Challenge;
using Quorum.DataApi.Controllers.Challenge.ResultsModels;
using Quorum.DataApi.Controllers.Challenge.ViewModels;
using Quorum.DataApi.Extensions;
using Quorum.DataApi.Filters;

namespace Quorum.DataApi.Controllers.Challenge
{
	[Route("api/pass")]
	[ModelValidationFilter]
	public sealed class ChallengeController : Controller
	{
		private readonly ITestRepository _tests;

		private readonly ChallengeModel _model;

		public ChallengeController(ITestRepository tests, ChallengeModel model)
		{
			_tests = tests;
			_model = model;
		}

		//get test data for challenge
		[HttpGet("{id}")]
		public async Task<ActionResult<ChallengeTestResultModel>> Get(int id)
		{
			var test = await _tests.GetAsync(id);

			if (test == null)
			{
				return NotFound(id);
			}

			return test.To<ChallengeTestResultModel>();
		}

		//post challenge results
		public async Task<ActionResult<int>> Post([FromBody] ChallengedTestViewModel test)
		{
			var entity = test.To<ChallengedTest>();
			
			try
			{
				var resultId = await _model.ChallengeTest(entity);
				return Ok(resultId);
			}
			catch
			{
				return UnprocessableEntity(test);
			}
		}
	}
}