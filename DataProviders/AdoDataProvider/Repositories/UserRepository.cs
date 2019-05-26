using System.Linq;
using System.Threading.Tasks;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.DataProviders.AdoDataProvider.Base;
using Quorum.DataProviders.AdoDataProvider.Extensions;
using Quorum.Domain.Entities.Domain;
using SqlKata.Execution;

namespace Quorum.DataProviders.AdoDataProvider.Repositories
{
	public sealed class UserRepository : AdoRepositoryBase<User>, IUserRepository
	{
		public UserRepository(QueryFactory queryFactory) : base(queryFactory) { }

		public override async Task<int> CreateAsync(User entity)
		{
			Query.ResetConditions();

			int id = await Query.InsertReturningIdAsync<int>(entity);

			entity.Id = id;

			return id;
		}

		public async Task<User> FindByEmailAsync(string email)
		{
			Query.ResetConditions();

			var users = await Query.Where("Email", email).GetAsync<User>();

			return users.FirstOrDefault();
		}
	}
}