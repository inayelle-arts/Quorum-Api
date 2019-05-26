using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.BusinessCore.Interfaces.Services;
using Quorum.DataApi.Controllers.Challenge.ResultsModels;
using Quorum.DataApi.Controllers.Challenge.ViewModels;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Extensions;
using ControllerBase = Quorum.DataApi.Base.ControllerBase;

namespace Quorum.DataApi.Controllers.Challenge
{
	[Route("api/pass")]
	public sealed class ChallengeController : ControllerBase
	{
		private readonly ITestRepository   _testRepository;
		private readonly IChallengeService _challengeService;

		public ChallengeController(ITestRepository testRepository, IChallengeService challengeService)
		{
			_testRepository   = testRepository;
			_challengeService = challengeService;
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<ChallengeTestResultModel>> GetChallenge(int id)
		{
			var test = await _testRepository.GetByIdAsync(id);

			if (test == null)
			{
				return NotFound(id);
			}

			return test.MapTo<ChallengeTestResultModel>();
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<ChallengeResultModel>> PostChallenge([FromBody] ChallengedTestViewModel test)
		{
			var entity = test.MapTo<ChallengedTest>();
			entity.UserId = UserId;

			try
			{
				int resultId = await _challengeService.PerformChallengeAsync(entity);
				return new ChallengeResultModel { Id = resultId };
			}
			catch
			{
				return UnprocessableEntity(test);
			}
		}
	}
}