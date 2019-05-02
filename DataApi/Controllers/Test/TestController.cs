using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Interfaces;
using Quorum.DataApi.Controllers.Test.ResultModels;
using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.DataApi.Filters;
using Quorum.Shared.Extensions;
using ControllerBase = Quorum.DataApi.Base.ControllerBase;

namespace Quorum.DataApi.Controllers.Test
{
	[Route("api/test")]
	[ModelValidationFilter]
	public sealed class TestController : ControllerBase
	{
		private readonly ITestRepository _testRepository;

		public TestController(ITestRepository testRepository)
		{
			_testRepository = testRepository;
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<int>> Create([FromBody] CreateTestViewModel test)
		{
			var entity = test.To<Entities.Domain.Test>();

			entity.UserId = UserId;

			await _testRepository.CreateAsync(entity);

			return entity.Id;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<TestPreviewResultModel>>> GetOwnTests()
		{
			var tests = await _testRepository.GetOwnTestsAsync(UserId);

			return tests.Select(t => t.To<TestPreviewResultModel>()).ToList();
		}
	}
}