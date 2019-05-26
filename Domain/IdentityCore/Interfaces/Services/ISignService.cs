using System.Threading.Tasks;
using Quorum.Domain.Entities.Identity;

namespace Quorum.Domain.IdentityCore.Interfaces.Services
{
	public interface ISignService
	{
		Task<QuorumUser> SignUpAsync(string email, string password, string role);

		Task<QuorumUser> SignInAsync(string email, string password);
	}
}