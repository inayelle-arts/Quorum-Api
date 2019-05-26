using System.Collections.Generic;
using System.Security.Claims;
using Quorum.Domain.Entities.Domain;

namespace Quorum.Domain.Entities.Extensions
{
	public static class UserExtensions
	{
		public static IEnumerable<Claim> GetClaims(this User user)
		{
			return new[]
			{
					new Claim("id", user.Id.ToString()),
					new Claim("email", user.Email),
					new Claim("role", user.Role)
			};
		}
	}
}