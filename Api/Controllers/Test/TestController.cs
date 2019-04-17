using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quorum.Api.Controllers.Test.ViewModels;
using Quorum.Api.Extensions;
using Quorum.Api.Filters;
using Quorum.BusinessCore.Entities;
using Quorum.BusinessCore.Interfaces;

namespace Quorum.Api.Controllers.Test
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

		public async Task<ActionResult<BusinessCore.Entities.Test>> Post([FromBody] CreateTestViewModel test)
		{
			var entity = test.To<BusinessCore.Entities.Test>();

			await _testRepository.Create(entity);

			return entity;
		}
	}
}