using AutoMapper;
using Quorum.Shared.Auxiliary;
using Quorum.Shared.Interfaces;

namespace Quorum.Shared.Extensions
{
	public static class EntityExtensions
	{
		public static IMapper Mapper => AutoMapper.Mapper.Instance;

		public static TTarget MapTo<TTarget>(this IEntity entity)
		{
			return Mapper.Map<TTarget>(entity);
		}

		public static TTarget MapTo<TTarget>(this IDataTransferObject dto)
				where TTarget : IEntity
		{
			return Mapper.Map<TTarget>(dto);
		}
	}
}