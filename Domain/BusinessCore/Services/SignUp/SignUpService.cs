using System.Threading.Tasks;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.BusinessCore.Interfaces.Services;
using Quorum.Domain.Entities.Domain;

namespace Quorum.BusinessCore.Services.SignUp
{
	public sealed class SignUpService : ISignUpService
	{
		private readonly IUserRepository _userRepository;
		
		public SignUpService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> SignUpAsync(User user)
		{
			var repoUser = await _userRepository.FindByEmailAsync(user.Email);

			if (repoUser != null)
			{
				return null;
			}

			await _userRepository.CreateAsync(user);

			return user;
		}
	}
}