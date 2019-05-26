using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.DataApi.Controllers.Result.ResultModels;
using Quorum.DataApi.Extensions;
using Quorum.Shared.Extensions;
using ControllerBase = Quorum.DataApi.Base.ControllerBase;

namespace Quorum.DataApi.Controllers.Result
{
	[Route("api/result")]
	public sealed class ResultController : ControllerBase
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

			return challengedTest.MapTo<PassedTestResultModel>();
		}

		[HttpGet("own")]
		[Authorize(Roles = Domain.Entities.Enums.UserRole.Student)]
		public async Task<ActionResult<IEnumerable<PassedTestPreviewResultModel>>> GetOwnResults()
		{
			var results = await _challengedTests.GetStudentsResultsAsync(UserId);

			return results.Select(r => r.MapTo<PassedTestPreviewResultModel>()).ToList();
		}
		
		[HttpGet("tutor")]
		[Authorize(Roles = Domain.Entities.Enums.UserRole.Tutor)]
		public async Task<ActionResult<IEnumerable<PassedTestPreviewResultModel>>> GetTutorResults()
		{
			var results = await _challengedTests.GetTutorsResultsAsync(UserId);

			return results.Select(r => r.MapTo<PassedTestPreviewResultModel>()).ToList();
		}
	}
}