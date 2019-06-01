using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Quorum.Domain.Entities.Identity;
using Quorum.Domain.IdentityCore.Interfaces.Repositories;

namespace Quorum.Domain.IdentityCore.Infrastructure.Commands.SignIn
{
	internal sealed class SignInCommand : IRequestHandler<SignInRequest, QuorumUser>
	{
		private readonly IQuorumUserRepository       _userRepository;
		private readonly IPasswordHasher<QuorumUser> _passwordHasher;

		public SignInCommand(IQuorumUserRepository userRepository, IPasswordHasher<QuorumUser> passwordHasher)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
		}

		public async Task<QuorumUser> Handle(SignInRequest request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByEmailAsync(request.Email);

			if (user == null)
			{
				return null;
			}

			return IsValidPassword(user, request.Password) ? user : null;
		}

		private bool IsValidPassword(QuorumUser user, string givenPassword)
		{
			return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, givenPassword) ==
				   PasswordVerificationResult.Success;
		}
	}
}