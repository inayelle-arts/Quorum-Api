using Microsoft.Extensions.DependencyInjection;
using Quorum.BusinessCore.Interfaces.Services;
using Quorum.BusinessCore.Services.Challenge;
using Quorum.BusinessCore.Services.SignUp;
using Quorum.BusinessCore.Services.Test;

namespace Quorum.BusinessCore.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddDomainServices(this IServiceCollection services)
		{
			services.AddScoped<ISignUpService, SignUpService>()
					.AddScoped<ITestService, TestService>()
					.AddScoped<IChallengeService, ChallengeService>();
		}
	}
}