using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quorum.Domain.Entities.Identity;
using Quorum.Domain.IdentityCore.Interfaces.Repositories;
using Quorum.Domain.IdentityCore.Interfaces.Services;

namespace Quorum.Domain.IdentityCore.Services.Sign
{
	internal sealed class SignService : ISignService
	{
		private readonly IQuorumUserRepository       _userRepository;
		private readonly IQuorumRoleRepository       _roleRepository;
		private readonly IPasswordHasher<QuorumUser> _passwordHasher;

		public SignService(IQuorumUserRepository       userRepository,
						   IPasswordHasher<QuorumUser> passwordHasher,
						   IQuorumRoleRepository       roleRepository
		)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
			_roleRepository = roleRepository;
		}

		public async Task<QuorumUser> SignUpAsync(int domainId, string email, string password, string roleName)
		{
			if (await _userRepository.IsEmailTakenAsync(email))
			{
				return null;
			}

			var role = await _roleRepository.GetByNameAsync(roleName);

			if (role == null)
			{
				throw new ArgumentException($"Unexpected role name {roleName}", nameof(roleName));
			}

			var user = new QuorumUser
			{
				DomainId = domainId,
				Email    = email,
				Role     = role
			};

			user.PasswordHash = _passwordHasher.HashPassword(user, password);

			await _userRepository.CreateAsync(user);

			return user;
		}

		public async Task<QuorumUser> SignInAsync(string email, string password)
		{
			var user = await _userRepository.GetByEmailAsync(email);

			if (user == null)
			{
				return null;
			}

			return IsValidPassword(user, password) ? user : null;
		}

		private bool IsValidPassword(QuorumUser user, string password)
		{
			return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) ==
				   PasswordVerificationResult.Success;
		}
	}
}