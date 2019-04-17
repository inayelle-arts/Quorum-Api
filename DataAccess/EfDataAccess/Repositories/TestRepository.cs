using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.BusinessCore.Entities;
using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.Ef.Base;

namespace Quorum.DataAccess.Ef.Repositories
{
	public sealed class TestRepository : RepositoryBase<Test, EfDataAccessContext>, ITestRepository
	{
		public TestRepository(EfDataAccessContext context) : base(context)
		{
		}

		public override async Task<Test> GetAsync(int id)
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