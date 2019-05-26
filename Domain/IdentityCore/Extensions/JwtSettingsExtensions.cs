using System.Text;
using Microsoft.IdentityModel.Tokens;
using Quorum.Domain.IdentityCore.Services.JwtAuthentication;

namespace Quorum.Domain.IdentityCore.Extensions
{
	internal static class JwtSettingsExtensions
	{
		public static SigningCredentials GetCredentials(this JwtSettings settings)
		{
			var signKeyBytes   = Encoding.UTF8.GetBytes(settings.SignKey);
			var signKeyCrypted = new SymmetricSecurityKey(signKeyBytes);

			return new SigningCredentials(signKeyCrypted, settings.HashingAlgorithm);
		}
	}
}