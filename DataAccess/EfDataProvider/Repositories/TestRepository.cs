using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Quorum.BusinessCore.Interfaces;
using Quorum.Entities;
using Quorum.Shared.Base;

namespace Quorum.DataAccess.EfDataProvider.Repositories
{
	public sealed class TestRepository : EfRepositoryBase<Test, EfDataContext>, ITestRepository
	{
		public TestRepository(EfDataContext context) : base(context)
		{
		}

		public override async Task<Test> GetByIdAsync(int id)
		{
			return await context.Tests
			                    .Where(t => t.Id == id)
			                    .Include(t => t.Tags)
			                    .Include(t => t.Questions)
			                    .ThenInclude(q => q.Answers)
			                    .FirstOrDefaultAsync();
		}
	}
}