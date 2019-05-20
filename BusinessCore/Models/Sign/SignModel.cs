using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quorum.BusinessCore.Interfaces;
using Quorum.Entities.Domain;

namespace Quorum.BusinessCore.Models.Sign
{
	public sealed class SignModel
	{
		private readonly IUserRepository       _userRepository;
		private readonly IPasswordHasher<User> _passwordHasher;

		public SignModel(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
		}

		public async Task<User> SignUp(User user, string password)
		{
			var repoUser = await _userRepository.FindByEmailAsync(user.Email);

			if (repoUser != null)
			{
				return null;
			}

			user.PasswordHash = _passwordHasher.HashPassword(user, password);

			await _userRepository.CreateAsync(user);

			return user;
		}

		public async Task<User> SignIn(string email, string password)
		{
			var repoUser = await _userRepository.FindByEmailAsync(email);

			if (repoUser == null)
			{
				return null;
			}

			return IsValidPassword(repoUser, password) ? repoUser : null;
		}

		private bool IsValidPassword(User user, string password)
		{
			return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) ==
			       PasswordVerificationResult.Success;
		}
	}
}