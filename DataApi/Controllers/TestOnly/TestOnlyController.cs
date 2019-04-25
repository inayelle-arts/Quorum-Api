using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.Shared.Extensions;

namespace DataApi.Controllers.TestOnly
{
	[Route("api/testonly")]
    public sealed class TestOnlyController : Controller
    {
		private readonly ITestRepository _repo;

		public TestOnlyController(ITestRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IEnumerable<Quorum.Entities.Test>> GetAll()
		{
			return await _repo.GetAll();
		}

		[HttpGet("{id}")]
		public async Task<Quorum.Entities.Test> GetById(int id)
		{
			return await _repo.GetByIdAsync(id);
		}

		[HttpPost]
		public async Task<int> Post([FromBody] CreateTestViewModel test)
		{
			return await _repo.Create(test.To<Quorum.Entities.Test>());
		}
    }
}