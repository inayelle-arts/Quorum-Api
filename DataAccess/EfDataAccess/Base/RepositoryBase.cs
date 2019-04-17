using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quorum.Shared.Interfaces;

namespace Quorum.DataAccess.Ef.Base
{
	public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
			where TEntity : class, IEntity, new()
			where TContext : DbContext
	{
		protected readonly TContext context;

		protected RepositoryBase(TContext context)
		{
			this.context = context;
		}

		public virtual async Task<TEntity> GetAsync(int id)
		{
			return await context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
		}

		public virtual async Task<ICollection<TEntity>> GetAll()
		{
			return await context.Set<TEntity>().ToListAsync();
		}

		public virtual async Task<bool> Update(TEntity entity)
		{
			context.Set<TEntity>().Update(entity);

			await context.SaveChangesAsync();

			return true;
		}

		public virtual async Task<bool> Delete(TEntity entity)
		{
			context.Set<TEntity>().Remove(entity);

			await context.SaveChangesAsync();

			return true;
		}

		public virtual async Task<int> Create(TEntity entity)
		{
			await context.Set<TEntity>().AddAsync(entity);

			await context.SaveChangesAsync();

			return entity.Id;
		}
	}
}