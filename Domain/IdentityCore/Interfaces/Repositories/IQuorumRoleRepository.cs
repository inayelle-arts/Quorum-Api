using System.Threading.Tasks;
using Quorum.Domain.Entities.Identity;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.IdentityCore.Interfaces.Repositories
{
	public interface IQuorumRoleRepository : IRepository<QuorumRole>
	{
		Task<QuorumRole> GetByNameAsync(string name);
	}
}