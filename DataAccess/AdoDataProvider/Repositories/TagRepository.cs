using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BusinessCore.Interfaces;

using Quorum.DataAccess.AdoDataProvider.Base;
using Quorum.DataAccess.AdoDataProvider.Extensions;
using Quorum.Entities;
using Quorum.Entities.Domain;
using SqlKata.Execution;

namespace Quorum.DataAccess.AdoDataProvider.Repositories
{
	public sealed class TagRepository : AdoRepositoryBase<Tag>, ITagRepository
	{
		public TagRepository(QueryFactory queryFactory) : base(queryFactory)
		{
		}

		public override async Task<int> CreateAsync(Tag tag)
		{
			var id = await Query.InsertReturningIdAsync<int>(new
			{
				tag.Content,
				tag.TestId
			});

			tag.Id = id;

			return id;
		}

		public async Task<ICollection<Tag>> GetByParentTestAsync(Test test)
		{
			var result = await Query.Where("TestId", test.Id).GetAsync<Tag>();

			return result.Select(t => { t.Test = test; return t; }).ToList();
		}
	}
}