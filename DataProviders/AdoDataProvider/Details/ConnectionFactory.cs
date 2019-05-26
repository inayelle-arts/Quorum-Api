using System.Data.Common;

using Npgsql;

namespace Quorum.DataProviders.AdoDataProvider.Details
{
    internal static class ConnectionFactory
    {
        public static DbConnection Create(string connectionString)
		{
			return new NpgsqlConnection(connectionString);
		}
    }
}