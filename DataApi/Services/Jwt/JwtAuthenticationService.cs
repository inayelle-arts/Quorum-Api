using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Quorum.DataApi.Interfaces;
using Quorum.Entities.Domain;
using Quorum.Entities.Extensions;

namespace Quorum.DataApi.Services.Jwt
{
	internal sealed class JwtAuthenticationService : IAuthenticationService
	{
		private readonly JwtSecurityTokenHandler _jwtHandler;

		private readonly JwtConfiguration _configuration;

		public JwtAuthenticationService(IConfiguration configuration, JwtSecurityTokenHandler jwtHandler)
		{
			_jwtHandler    = jwtHandler;
			_configuration = new JwtConfiguration(configuration.GetSection("Authentication"));
		}

		public string GenerateToken(User user)
		{
			var expireTime = DateTime.UtcNow.AddMinutes(_configuration.TokenLifetime);

			var token = new JwtSecurityToken(
					issuer: _configuration.Issuer,
					audience: _configuration.Audience,
					notBefore: DateTime.UtcNow,
					expires: expireTime,
					signingCredentials: _configuration.Credentials,
					claims: user.GetClaims()
			);

			return _jwtHandler.WriteToken(token);
		}
	}
}