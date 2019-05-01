using System.Threading.Tasks;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> FindByEmailAsync(string email);
	}
}