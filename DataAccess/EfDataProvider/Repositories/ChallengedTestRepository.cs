using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Quorum.BusinessCore.Interfaces;
using Quorum.Entities;
using Quorum.Shared.Base;

namespace Quorum.DataAccess.EfDataProvider.Repositories
{
	public sealed class ChallengedTestRepository : EfRepositoryBase<ChallengedTest, EfDataContext>,
	                                               IChallengedTestRepository
	{
		public ChallengedTestRepository(EfDataContext context) : base(context)
		{
		}

		public override async Task<ChallengedTest> GetByIdAsync(int id)
		{
			return await context.PassedTests
			                    .Where(t => t.Id == id)
			                    .Include(t => t.SourceTest)
			                    .Include(t => t.Questions)
			                    .ThenInclude(q => q.SourceQuestion)
			                    .Include(t => t.Questions)
			                    .ThenInclude(q => q.Answers)
			                    .ThenInclude(a => a.SourceAnswer)
			                    .FirstOrDefaultAsync();
		}
	}
}