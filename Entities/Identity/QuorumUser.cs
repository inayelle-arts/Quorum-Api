using Microsoft.AspNetCore.Identity;
using Quorum.Shared.Interfaces;

namespace Quorum.Entities.Identity
{
	public class QuorumUser : IdentityUser, IEntity<string>
	{
		
	}
}