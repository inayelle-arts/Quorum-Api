using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Quorum.DataApi.Services.Jwt
{
	internal sealed class JwtConfiguration
	{
		public string Audience { get; }
		public string Issuer   { get; }

		public int                TokenLifetime { get; }
		public SigningCredentials Credentials   { get; }

		public JwtConfiguration(IConfiguration jwtConfiguration)
		{
			Audience      = jwtConfiguration["Audience"];
			Issuer        = jwtConfiguration["Issuer"];
			TokenLifetime = jwtConfiguration.GetValue<int>("Lifetime");

			var signKey        = Encoding.UTF8.GetBytes(jwtConfiguration["SignKey"]);
			var signKeyCrypted = new SymmetricSecurityKey(signKey);
			
			Credentials = new SigningCredentials(signKeyCrypted, jwtConfiguration["Algorithm"]);
		}
	}
}