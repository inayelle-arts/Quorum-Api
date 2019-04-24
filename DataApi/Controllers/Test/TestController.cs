using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quorum.BusinessCore.Interfaces;
using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.DataApi.Filters;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Controllers.Test
{
	[Route("api/test")]
	[ModelValidationFilter]
	public sealed class TestController : Controller
	{
		private readonly ITestRepository _testRepository;

		public TestController(ITestRepository testRepository)
		{
			_testRepository = testRepository;
		}

		[HttpPost]
		public async Task<ActionResult<Entities.Test>> Post([FromBody] CreateTestViewModel test)
		{
			var entity = test.To<Entities.Test>();

			await _testRepository.Create(entity);

			return entity;
		}
	}
}