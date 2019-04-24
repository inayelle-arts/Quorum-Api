using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.DataApi.Filters;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Controllers.Create
{
	[Route("api/create")]
	[ModelValidationFilter]
	public sealed class CreateController : Controller
	{
		private readonly ITestRepository _testRepository;

		public CreateController(ITestRepository testRepository)
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