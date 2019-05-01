using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Models.Challenge;
using Quorum.DataApi.Controllers.Challenge.ResultsModels;
using Quorum.DataApi.Controllers.Challenge.ViewModels;
using Quorum.DataApi.Filters;
using Quorum.Entities;
using Quorum.Entities.Domain;
using Quorum.Shared.Extensions;
using ControllerBase = Quorum.DataApi.Base.ControllerBase;

namespace Quorum.DataApi.Controllers.Challenge
{
	[Route("api/pass")]
	[ModelValidationFilter]
	public sealed class ChallengeController : ControllerBase
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
		[Authorize]
		public async Task<ActionResult<ChallengeTestResultModel>> Get(int id)
		{
			var test = await _tests.GetByIdAsync(id);

			if (test == null)
			{
				return NotFound(id);
			}

			return test.To<ChallengeTestResultModel>();
		}

		//post challenge results
		[HttpPost]
		[Authorize]
		public async Task<ActionResult<ChallengeResultModel>> Post([FromBody] ChallengedTestViewModel test)
		{
			var entity = test.To<ChallengedTest>();
			entity.UserId = UserId;

			try
			{
				var resultId = await _model.ChallengeTest(entity);
				return new ChallengeResultModel { Id = resultId };
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
				return UnprocessableEntity(test);
			}
		}
	}
}