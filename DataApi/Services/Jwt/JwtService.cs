using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Quorum.DataApi.Extensions;
using Quorum.DataApi.Interfaces;
using Quorum.Entities.Domain;

namespace Quorum.DataApi.Services.Jwt
{
	internal sealed class JwtService : IJwtService
	{
		private readonly JwtSecurityTokenHandler _jwtHandler;

		private readonly JwtConfiguration _configuration;

		public JwtService(IConfiguration configuration, JwtSecurityTokenHandler jwtHandler)
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