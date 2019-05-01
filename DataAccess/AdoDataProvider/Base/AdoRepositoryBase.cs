using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

using Quorum.DataAccess.AdoDataProvider.Extensions;
using Quorum.Shared.Interfaces;

using SqlKata;
using SqlKata.Execution;

namespace Quorum.DataAccess.AdoDataProvider.Base
{
	public abstract class AdoRepositoryBase<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity, new()
	{
		private readonly Query _query;

		protected Query Query
		{
			get
			{
				_query.ResetConditions();
				return _query;
			}
		}

		public AdoRepositoryBase(QueryFactory queryFactory)
		{
			var table = typeof(TEntity).Name + "s";

			this._query = queryFactory.Query(table);
		}

		public abstract Task<int> CreateAsync(TEntity entity);
		// {
		// 	var id = await query.InsertReturningId<int>(entity);

		// 	entity.Id = id;

		// 	return id;
		// }

		public virtual async Task<IEnumerable<int>> CreateAsync(IEnumerable<TEntity> entites)
		{
			var ids = new List<int>();

			foreach (var entity in entites)
			{
				ids.Add(await CreateAsync(entity));
			}

			return ids;
		}

		public virtual async Task<bool> DeleteAsync(TEntity entity)
		{
			await Query.Where("Id", entity.Id.ToString()).DeleteAsync();

			return true;
		}

		public virtual async Task<ICollection<TEntity>> GetAllAsync()
		{
			var result = await Query.GetAsync<TEntity>();

			return result.ToList();
		}

		public virtual async Task<TEntity> GetByIdAsync(int id)
		{
			var result = await Query.Where("Id", id).Distinct().GetAsync<TEntity>();

			return result.FirstOrDefault();
		}

		public virtual async Task<bool> UpdateAsync(TEntity entity)
		{
			await Query.Where("Id", entity.Id).UpdateAsync(entity);

			return true;
		}
	}
}