using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Quorum.Domain.Entities.Identity;
using Quorum.Domain.IdentityCore.Interfaces.Repositories;

namespace Quorum.Domain.IdentityCore.Infrastructure.Commands.SignUp
{
	internal sealed class SignUpCommand : IRequestHandler<SignUpRequest, QuorumUser>
	{
		private readonly IQuorumUserRepository       _userRepository;
		private readonly IQuorumRoleRepository       _roleRepository;
		private readonly IPasswordHasher<QuorumUser> _passwordHasher;

		public SignUpCommand(IQuorumUserRepository       userRepository,
							 IQuorumRoleRepository       roleRepository,
							 IPasswordHasher<QuorumUser> passwordHasher
		)
		{
			_userRepository = userRepository;
			_roleRepository = roleRepository;
			_passwordHasher = passwordHasher;
		}

		public async Task<QuorumUser> Handle(SignUpRequest request, CancellationToken cancellationToken)
		{
			if (await _userRepository.IsEmailTakenAsync(request.Email))
			{
				return null;
			}

			var role = await _roleRepository.GetByNameAsync(request.Role);

			if (role == null)
			{
				throw new ArgumentException($"Invalid role {request.Role}");
			}

			var user = new QuorumUser
			{
				DomainId = request.DomainId,
				Email    = request.Email,
				Role     = role
			};

			user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

			await _userRepository.CreateAsync(user);

			return user;
		}
	}
}