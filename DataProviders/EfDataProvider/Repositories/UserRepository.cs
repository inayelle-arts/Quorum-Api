using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Base;

namespace Quorum.DataProviders.EfDataProvider.Repositories
{
	public sealed class UserRepository : EfRepositoryBase<User, EfDataContext>, IUserRepository
	{
		public UserRepository(EfDataContext context) : base(context)
		{
		}

		public async Task<User> FindByEmailAsync(string email)
		{
			return await Context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
		}
	}
}