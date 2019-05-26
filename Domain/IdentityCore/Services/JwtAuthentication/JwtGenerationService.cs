using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Quorum.Domain.Entities.Identity;
using Quorum.Domain.IdentityCore.Extensions;
using Quorum.Domain.IdentityCore.Interfaces.Services;

namespace Quorum.Domain.IdentityCore.Services.JwtAuthentication
{
	public class JwtGenerationService : IJwtGenerationService
	{
		private readonly JwtSecurityTokenHandler _jwtHandler;
		private readonly SigningCredentials      _credentials;

		private readonly JwtSettings _settings;

		public JwtGenerationService(JwtSecurityTokenHandler jwtHandler, JwtSettings settings)
		{
			_jwtHandler = jwtHandler;
			_settings   = settings;

			_credentials = _settings.GetCredentials();
		}

		public string GenerateToken(QuorumUser user)
		{
			var expireTime = DateTime.UtcNow.AddMinutes(_settings.TokenLifetime);

			var token = new JwtSecurityToken(issuer: _settings.Issuer,
											 audience: _settings.Audience,
											 notBefore: DateTime.UtcNow,
											 expires: expireTime,
											 signingCredentials: _credentials,
											 claims: user.GetClaims());

			return _jwtHandler.WriteToken(token);
		}
	}
}