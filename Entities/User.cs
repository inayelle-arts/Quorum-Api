using Microsoft.AspNetCore.Identity;
using Quorum.Shared.Interfaces;

namespace Quorum.Entities
{
	public class User : IdentityUser, IEntity<string>
	{
	}
}