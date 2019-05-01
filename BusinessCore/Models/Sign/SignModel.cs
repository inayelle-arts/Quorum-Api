using System.Threading.Tasks;
using Quorum.BusinessCore.Interfaces;
using Quorum.Entities.Domain;

namespace Quorum.BusinessCore.Models.Sign
{
	public sealed class SignModel
	{
		private readonly IUserRepository _userRepository;

		public SignModel(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> SignUp(User user)
		{
			var repoUser = await _userRepository.FindByEmailAsync(user.Email);

			if (repoUser != null)
			{
				return null;
			}

			await _userRepository.CreateAsync(user);

			return user;
		}

		public async Task<User> SignIn(User user)
		{
			var repoUser = await _userRepository.FindByEmailAsync(user.Email);

			if (repoUser == null)
			{
				return null;
			}

			if (!repoUser.Password.Equals(user.Password))
			{
				return null;
			}

			return repoUser;
		}
	}
}