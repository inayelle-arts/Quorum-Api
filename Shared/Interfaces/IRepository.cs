using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quorum.Shared.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class, IEntity, new()
	{
		Task<TEntity> GetAsync(int id);

		Task<ICollection<TEntity>> GetAll();

		Task<bool> Update(TEntity entity);

		Task<bool> Delete(TEntity entity);

		Task<int> Create(TEntity entity);
	}
}