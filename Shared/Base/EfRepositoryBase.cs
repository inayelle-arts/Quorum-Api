using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Quorum.Shared.Interfaces;

namespace Quorum.Shared.Base
{
	public abstract class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
			where TEntity : class, IEntity, new()
			where TContext : DbContext
	{
		protected readonly TContext context;

		protected EfRepositoryBase(TContext context)
		{
			this.context = context;
		}

		public virtual async Task<TEntity> GetByIdAsync(int id)
		{
			return await context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
		}

		public virtual async Task<ICollection<TEntity>> GetAllAsync()
		{
			return await context.Set<TEntity>().ToListAsync();
		}

		public virtual async Task<bool> UpdateAsync(TEntity entity)
		{
			context.Set<TEntity>().Update(entity);

			await context.SaveChangesAsync();

			return true;
		}

		public virtual async Task<bool> DeleteAsync(TEntity entity)
		{
			context.Set<TEntity>().Remove(entity);

			await context.SaveChangesAsync();

			return true;
		}

		public virtual async Task<int> CreateAsync(TEntity entity)
		{
			await context.Set<TEntity>().AddAsync(entity);

			await context.SaveChangesAsync();

			return entity.Id;
		}

		public virtual async Task<IEnumerable<int>> CreateAsync(IEnumerable<TEntity> entities)
		{
			await context.Set<TEntity>().AddRangeAsync(entities);

			await context.SaveChangesAsync();

			return entities.Select(e => e.Id);
		}
	}
}