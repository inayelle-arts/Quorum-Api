using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.DataApi.Filters;
using Quorum.Shared.Extensions;
using ControllerBase = Quorum.DataApi.Base.ControllerBase;

namespace Quorum.DataApi.Controllers.Create
{
	[Route("api/create")]
	[ModelValidationFilter]
	public sealed class CreateController : ControllerBase
	{
		private readonly ITestRepository _testRepository;

		public CreateController(ITestRepository testRepository)
		{
			_testRepository = testRepository;
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<Entities.Domain.Test>> Post([FromBody] CreateTestViewModel test)
		{
			var entity = test.To<Entities.Domain.Test>();

			entity.UserId = UserId;

			await _testRepository.CreateAsync(entity);

			return entity;
		}
	}
}