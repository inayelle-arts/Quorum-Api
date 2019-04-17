using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quorum.Shared.Extensions
{
	public static class AssemblyExtensionsExtensions
	{
		public static IEnumerable<Type> GetTypesWithPostfix(this Assembly assembly, string postfix)
		{
			return assembly.GetExportedTypes()
			               .Where(t => t.Name.EndsWith(postfix, StringComparison.Ordinal))
			               .ToList();
		}
	}
}