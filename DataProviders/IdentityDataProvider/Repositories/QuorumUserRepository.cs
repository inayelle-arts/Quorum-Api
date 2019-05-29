using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.Domain.Entities.Identity;
using Quorum.Domain.IdentityCore.Interfaces.Repositories;
using Quorum.Shared.Base;

namespace Quorum.DataProviders.IdentityDataProvider.Repositories
{
	internal sealed class QuorumUserRepository : EfRepositoryBase<QuorumUser, IdentityDataContext>,
												 IQuorumUserRepository
	{
		public QuorumUserRepository(IdentityDataContext context) : base(context) { }

		public override Task<QuorumUser> GetByIdAsync(int id)
		{
			return Context.QuorumUsers
						  .Where(u => u.Id == id)
						  .Include(u => u.Role)
						  .FirstOrDefaultAsync();
		}

		public Task<QuorumUser> GetByEmailAsync(string email)
		{
			return Context.QuorumUsers
						  .Where(u => u.Email == email)
						  .Include(u => u.Role)
						  .FirstOrDefaultAsync();
		}

		public Task<bool> IsEmailTakenAsync(string email)
		{
			return Context.QuorumUsers.AnyAsync(u => u.Email == email);
		}
	}
}