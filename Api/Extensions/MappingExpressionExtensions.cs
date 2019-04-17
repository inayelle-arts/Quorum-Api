using System;
using System.Linq.Expressions;
using AutoMapper;

namespace Quorum.Api.Extensions
{
	internal static class MappingExpressionExtensions
	{
		public static IMappingExpression<TSource, TTarget> ForField<TSource, TTarget, TSourceType, TTargetType>
		(
				this IMappingExpression<TSource, TTarget> mapping,
				Expression<Func<TSource, TSourceType>>    source,
				Expression<Func<TTarget, TTargetType>>    target
		)
				where TSourceType : TTargetType
		{
			mapping.ForMember(target, options => { options.MapFrom(source); });

			return mapping;
		}
	}
}