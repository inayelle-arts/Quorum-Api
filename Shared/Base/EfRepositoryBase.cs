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
		protected TContext Context { get; }

		protected EfRepositoryBase(TContext context)
		{
			Context = context;
		}

		public virtual async Task<TEntity> GetByIdAsync(int id)
		{
			return await Context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id));
		}

		public virtual async Task<ICollection<TEntity>> GetAllAsync()
		{
			return await Context.Set<TEntity>().ToListAsync();
		}

		public virtual async Task<bool> UpdateAsync(TEntity entity)
		{
			Context.Set<TEntity>().Update(entity);

			await Context.SaveChangesAsync();

			return true;
		}

		public virtual async Task<bool> DeleteAsync(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);

			await Context.SaveChangesAsync();

			return true;
		}

		public virtual async Task<int> CreateAsync(TEntity entity)
		{
			await Context.Set<TEntity>().AddAsync(entity);

			await Context.SaveChangesAsync();

			return entity.Id;
		}

		public virtual async Task<ICollection<int>> CreateAsync(ICollection<TEntity> entities)
		{
			await Context.Set<TEntity>().AddRangeAsync(entities);

			await Context.SaveChangesAsync();

			return entities.Select(e => e.Id).ToList();
		}
	}
}