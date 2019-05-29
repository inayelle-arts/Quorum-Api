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
	internal sealed class ChallengedTestRepository : EfRepositoryBase<ChallengedTest, EfDataContext>,
													 IChallengedTestRepository
	{
		public ChallengedTestRepository(EfDataContext context) : base(context) { }

		public override Task<ChallengedTest> GetByIdAsync(int id)
		{
			return Context.ChallengedTests
						  .Where(t => t.Id == id)
						  .Include(t => t.User)
						  .Include(t => t.SourceTest)
						  .Include(t => t.Questions)
						  .ThenInclude(q => q.SourceQuestion)
						  .Include(t => t.Questions)
						  .ThenInclude(q => q.Answers)
						  .ThenInclude(a => a.SourceAnswer)
						  .FirstOrDefaultAsync();
		}

		public async Task<ICollection<ChallengedTest>> GetStudentsResultsAsync(int userId)
		{
			return await Context.ChallengedTests
								.Where(t => t.UserId == userId)
								.Include(t => t.User)
								.Include(t => t.SourceTest)
								.Include(t => t.Questions)
								.ThenInclude(q => q.SourceQuestion)
								.Include(t => t.Questions)
								.ThenInclude(q => q.Answers)
								.ThenInclude(a => a.SourceAnswer)
								.ToListAsync();
		}

		public async Task<ICollection<ChallengedTest>> GetTutorsResultsAsync(int userId)
		{
			return await Context.ChallengedTests
								.Where(t => t.SourceTest.UserId == userId)
								.Include(t => t.User)
								.Include(t => t.SourceTest)
								.Include(t => t.Questions)
								.ThenInclude(q => q.SourceQuestion)
								.Include(t => t.Questions)
								.ThenInclude(q => q.Answers)
								.ThenInclude(a => a.SourceAnswer)
								.ToListAsync();
		}
	}
}