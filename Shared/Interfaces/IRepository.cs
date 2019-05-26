using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quorum.Shared.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class, IEntity, new()
	{
		Task<TEntity> GetByIdAsync(int id);

		Task<ICollection<TEntity>> GetAllAsync();

		Task<bool> UpdateAsync(TEntity entity);

		Task<bool> DeleteAsync(TEntity entity);

		Task<int> CreateAsync(TEntity entity);

		Task<ICollection<int>> CreateAsync(ICollection<TEntity> entities);
	}
}