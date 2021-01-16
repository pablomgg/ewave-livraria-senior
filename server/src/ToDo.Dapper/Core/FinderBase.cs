using System;
using System.Data;
using System.Data.SqlClient;

namespace ToDo.Dapper.Core
{
    public class FinderBase
    {
        protected readonly string ConnectionString;

        public FinderBase(string connectionString) => ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

        protected virtual IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}