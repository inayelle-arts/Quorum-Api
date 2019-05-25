using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Quorum.DataApi.Extensions;
using Quorum.DataApi.Interfaces;
using Quorum.DataApi.Settings;
using Quorum.Entities.Domain;
using Quorum.Entities.Extensions;

namespace Quorum.DataApi.Services.Jwt
{
	internal sealed class JwtAuthenticationService : IAuthenticationService
	{
		private readonly JwtSecurityTokenHandler _jwtHandler;

		private readonly JwtSettings _settings;

		private readonly SigningCredentials _credentials;

		public JwtAuthenticationService(JwtSettings settings, JwtSecurityTokenHandler jwtHandler)
		{
			_jwtHandler  = jwtHandler;
			_settings    = settings;
			_credentials = settings.GetCredentials();
		}

		public string GenerateToken(User user)
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