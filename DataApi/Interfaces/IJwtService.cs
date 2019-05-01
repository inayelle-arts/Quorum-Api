using Quorum.Entities.Domain;

namespace Quorum.DataApi.Interfaces
{
	public interface IJwtService
	{
		string GenerateToken(User user);
	}
}