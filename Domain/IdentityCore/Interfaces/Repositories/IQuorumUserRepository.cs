using System.Threading.Tasks;
using Quorum.Domain.Entities.Identity;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.IdentityCore.Interfaces.Repositories
{
	public interface IQuorumUserRepository : IRepository<QuorumUser>
	{
		Task<QuorumUser> GetByEmailAsync(string email);
	}
}