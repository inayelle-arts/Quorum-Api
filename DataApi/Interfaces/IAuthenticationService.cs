using Quorum.Entities.Domain;

namespace Quorum.DataApi.Interfaces
{
	public interface IAuthenticationService
	{
		string GenerateToken(User user);
	}
}