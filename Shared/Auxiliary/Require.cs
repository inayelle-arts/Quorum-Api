using System;
using System.Runtime.CompilerServices;

namespace Quorum.Shared.Auxiliary
{
	public static class Require
	{
		public static T NotNull<T>(T obj, [CallerMemberName] string name = null)
				where T : class
		{
			if (obj == null)
			{
				throw new ArgumentNullException(name);
			}

			return obj;
		}

		public static T That<T>(T obj, Func<T, bool> condition, [CallerMemberName] string name = null)
				where T : class
		{
			if (condition(obj))
			{
				return obj;
			}

			throw new ArgumentException(name);
		}
	}
}