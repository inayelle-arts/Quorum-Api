using System.Threading.Tasks;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces.Repositories
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> FindByEmailAsync(string email);
	}
}