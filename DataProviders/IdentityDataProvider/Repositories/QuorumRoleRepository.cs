using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.Domain.Entities.Identity;
using Quorum.Domain.IdentityCore.Interfaces.Repositories;
using Quorum.Shared.Base;

namespace Quorum.DataProviders.IdentityDataProvider.Repositories
{
	internal sealed class QuorumRoleRepository : EfRepositoryBase<QuorumRole, IdentityDataContext>,
												 IQuorumRoleRepository
	{
		public QuorumRoleRepository(IdentityDataContext context) : base(context) { }

		public Task<QuorumRole> GetByNameAsync(string name)
		{
			return Context.QuorumRoles.Where(r => r.Name == name).FirstOrDefaultAsync();
		}
	}
}