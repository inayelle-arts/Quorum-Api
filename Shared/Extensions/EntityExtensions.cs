using AutoMapper;
using Quorum.Shared.Auxiliary;
using Quorum.Shared.Interfaces;

namespace Quorum.Shared.Extensions
{
	public static class EntityExtensions
	{
		private static IMapper _mapper;

		public static IMapper Mapper
		{
			get => _mapper;
			set => _mapper = Require.NotNull(value);
		}

		public static TTarget To<TTarget>(this IEntity entity)
		{
			return _mapper.Map<TTarget>(entity);
		}

		public static TTarget To<TTarget>(this IDataTransferObject dto)
				where TTarget : IEntity
		{
			return _mapper.Map<TTarget>(dto);
		}
	}
}