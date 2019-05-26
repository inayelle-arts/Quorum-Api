using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.Domain.Entities.Identity;
using Quorum.Domain.IdentityCore.Interfaces.Repositories;
using Quorum.Shared.Base;

namespace Quorum.DataProviders.IdentityDataProvider.Repositories
{
	public sealed class QuorumUserRepository : EfRepositoryBase<QuorumUser, IdentityDataContext>, IQuorumUserRepository
	{
		public QuorumUserRepository(IdentityDataContext context) : base(context) { }

		public async Task<QuorumUser> GetByEmailAsync(string email)
		{
			return await Context.QuorumUsers.Where(u => u.Email == email).FirstOrDefaultAsync();
		}
	}
}