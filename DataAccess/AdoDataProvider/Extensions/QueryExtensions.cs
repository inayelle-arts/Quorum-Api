using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SqlKata;
using SqlKata.Execution;

namespace Quorum.DataAccess.AdoDataProvider.Extensions
{
    internal static class QueryExtensions
    {
        public static async Task<TId> InsertReturningIdAsync<TId>(this Query query, object data)
		{
			var ids = await query.AsInsert(data, true).GetAsync<TId>();

			return ids.First();
		}

		public static async Task<IList<TId>> InsertReturningIdAsync<TId>(this Query query, IEnumerable<object> data)
		{
			var ids = new List<TId>();

			foreach (var dataPart in data)
			{
				ids.Add(await query.InsertReturningIdAsync<TId>(dataPart));
			}

			return ids;
		}

		public static void ResetConditions(this Query query)
		{
			query.Clauses.RemoveAll(c => c is AbstractCondition);
		}
    }
}