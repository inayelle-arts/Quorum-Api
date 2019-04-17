using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.BusinessCore.Entities;
using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.Ef.Base;

namespace Quorum.DataAccess.Ef.Repositories
{
	public sealed class ChallengedTestRepository : RepositoryBase<ChallengedTest, EfDataAccessContext>,
	                                               IChallengedTestRepository
	{
		public ChallengedTestRepository(EfDataAccessContext context) : base(context)
		{
		}

		public override async Task<ChallengedTest> GetAsync(int id)
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