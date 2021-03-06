using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Base;

namespace Quorum.DataProviders.EfDataProvider.Repositories
{
	internal sealed class TestRepository : EfRepositoryBase<Test, EfDataContext>, ITestRepository
	{
		public TestRepository(EfDataContext context) : base(context) { }

		public override Task<Test> GetByIdAsync(int id)
		{
			return Context.Tests
						  .Where(t => t.Id == id)
						  .Include(t => t.Tags)
						  .Include(t => t.Questions)
						  .ThenInclude(q => q.Answers)
						  .FirstOrDefaultAsync();
		}

		public async Task<ICollection<Test>> GetTutorOwnTestsAsync(int userId)
		{
			return await Context.Tests
								.Where(t => t.UserId == userId)
								.Include(t => t.Tags)
								.Include(t => t.Questions)
								.ThenInclude(q => q.Answers)
								.ToListAsync();
		}
	}
}