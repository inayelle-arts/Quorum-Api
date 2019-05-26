using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Quorum.Domain.Entities.Identity;
using Quorum.Domain.IdentityCore.Interfaces.Services;
using Quorum.Domain.IdentityCore.Services.JwtAuthentication;
using Quorum.Domain.IdentityCore.Services.Sign;

namespace Quorum.Domain.IdentityCore.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddIdentityCoreServices(this IServiceCollection services)
		{
			services.AddSingleton<IPasswordHasher<QuorumUser>, PasswordHasher<QuorumUser>>()
					.AddSingleton<JwtSecurityTokenHandler>()
					.AddSingleton<IJwtGenerationService, JwtGenerationService>();

			services.AddScoped<ISignService, SignService>();
		}
	}
}