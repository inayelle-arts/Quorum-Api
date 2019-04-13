using System.Collections.Generic;

namespace Quorum.Shared.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class, IEntity, new()
	{
		TEntity Get(int id);

		IEnumerable<TEntity> GetAll();

		void Update(TEntity entity);

		void Delete(TEntity entity);

		void Create(TEntity entity);
	}
}