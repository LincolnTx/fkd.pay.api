using System;
using Npgsql;
using System.Data;

namespace fkd.pay.api.Application.QueryHandlers
{
    public abstract class QueryHandler
    {
        private readonly string _connectionString = Environment.GetEnvironmentVariable("ConnectionString");

        internal IDbConnection DbConnection => new NpgsqlConnection(_connectionString);
    }
}