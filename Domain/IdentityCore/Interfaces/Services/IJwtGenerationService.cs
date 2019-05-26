using Quorum.Domain.Entities.Identity;

namespace Quorum.Domain.IdentityCore.Interfaces.Services
{
	public interface IJwtGenerationService
	{
		string GenerateToken(QuorumUser user);
	}
}