using System.Collections.Generic;
using System.Security.Claims;
using Quorum.Entities.Domain;

namespace Quorum.DataApi.Extensions
{
	internal static class UserExtensions
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