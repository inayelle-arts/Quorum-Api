using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.BusinessCore.Interfaces;
using Quorum.Entities.Domain;
using Quorum.Shared.Base;

namespace Quorum.DataAccess.EfDataProvider.Repositories
{
	public sealed class UserRepository : EfRepositoryBase<User, EfDataContext>, IUserRepository
	{
		public UserRepository(EfDataContext context) : base(context)
		{
		}

		public async Task<User> FindByEmailAsync(string email)
		{
			return await context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
		}
	}
}