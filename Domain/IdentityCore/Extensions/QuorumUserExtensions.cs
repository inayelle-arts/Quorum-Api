using System.Collections.Generic;
using System.Security.Claims;
using Quorum.Domain.Entities.Identity;

namespace Quorum.Domain.IdentityCore.Extensions
{
	public static class QuorumUserExtensions
	{
		public static IEnumerable<Claim> GetClaims(this QuorumUser user)
		{
			return new[]
			{
				new Claim("id", user.DomainId.ToString()),
				new Claim("email", user.Email),
				new Claim("role", user.Role)
			};
		}
	}
}