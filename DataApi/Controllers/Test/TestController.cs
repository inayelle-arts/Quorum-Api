using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Interfaces.Services;
using Quorum.DataApi.Controllers.Test.ResultModels;
using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.Shared.Extensions;
using ControllerBase = Quorum.DataApi.Base.ControllerBase;

namespace Quorum.DataApi.Controllers.Test
{
	[Route("api/test")]
	public sealed class TestController : ControllerBase
	{
		private readonly ITestService _testService;

		public TestController(ITestService testService)
		{
			_testService = testService;
		}

		[HttpPost]
		[Authorize(Roles = Domain.Entities.Enums.UserRole.Tutor)]
		public async Task<ActionResult<int>> Create([FromBody] CreateTestViewModel test)
		{
			var entity = test.MapTo<Domain.Entities.Domain.Test>();
			entity.UserId = UserId;

			await _testService.CreateTestAsync(entity);

			return entity.Id;
		}

		[HttpGet]
		[Authorize(Roles = Domain.Entities.Enums.UserRole.Tutor)]
		public async Task<ActionResult<IEnumerable<TestPreviewResultModel>>> GetTestsPreviews()
		{
			var tests = await _testService.GetTutorOwnTestsAsync(UserId);

			return tests.Select(t => t.MapTo<TestPreviewResultModel>()).ToList();
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = Domain.Entities.Enums.UserRole.Tutor)]
		public async Task<ActionResult<int>> DeleteTest(int id)
		{
			var test = await _testService.DeleteTestAsync(id);

			if (test == null)
			{
				return NotFound(id);
			}

			return Ok(id);
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult> PatchShuffleQuestionsToggle(int                                        id,
																	[FromBody] PatchTestShuffleQuestionsToggle viewModel
		)
		{
			var test = await _testService.ToggleTestShuffleQuestionsAsync(id, viewModel.ShuffleQuestions);

			if (test == null)
			{
				return NotFound(id);
			}

			return Ok();
		}
	}
}