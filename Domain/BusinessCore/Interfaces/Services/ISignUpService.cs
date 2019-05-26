using System.Threading.Tasks;
using Quorum.Domain.Entities.Domain;

namespace Quorum.BusinessCore.Interfaces.Services
{
	public interface ISignUpService
	{
		Task<User> SignUpAsync(User user);
	}
}