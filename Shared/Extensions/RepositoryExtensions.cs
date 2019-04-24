using System.Threading.Tasks;
using Quorum.Shared.Interfaces;

namespace Quorum.Shared.Extensions
{
	public static class RepositoryExtensionsExtensions
	{
		public static async Task<bool> Exists<TEntity>(this IRepository<TEntity> repository, int id)
				where TEntity : class, IEntity, new()
		{
			return await repository.GetByIdAsync(id) != null;
		}
	}
}