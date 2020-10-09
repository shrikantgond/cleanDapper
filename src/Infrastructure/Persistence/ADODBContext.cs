using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CleanApp.Application.Common.Interfaces;
using Dapper;

namespace CleanApp.Infrastructure.Persistence
{

    class ADODBContext<T> : IADODBContext<T> where T : class
    {
        private readonly string _tableName;
        protected string _connectionString;

        public ADODBContext(IDatabaseSettings configuration)
        {
            _connectionString = configuration.ConnectionString;
            _tableName = typeof(T).Name;
        }

        public async Task<long> AddAsync(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {_tableName} ({stringOfColumns}) values ({stringOfParameters}); SELECT CAST(SCOPE_IDENTITY() as bigint)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var result = await conn.QueryAsync<long>(query, entity);
                return result.FirstOrDefault();
            }
        }

        public async Task<List<T>> ExecuteStoredProc(string spName, object parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryMultipleAsync(spName, parameters,
                commandType: CommandType.StoredProcedure);

                return result.Read<T>().ToList();

            }
        }

        public async Task DeleteAsync(long ID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                await conn.ExecuteAsync($"DELETE FROM {_tableName} WHERE [ID] = @ID", new { ID = ID });
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var data = await conn.QueryAsync<T>($"SELECT * FROM {_tableName}");
                return data;
            }
        }
        public async Task<T> GetByIDAsync(long ID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var data = await conn.QueryAsync<T>($"SELECT * FROM {_tableName} WHERE ID = @ID", new { ID = ID });
                return data.FirstOrDefault();
            }

        }
        public async Task UpdateAsync(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {_tableName} set {stringOfColumns} where ID = @ID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(query, entity);
            }
        }
        public async Task<IEnumerable<T>> QueryAsync(string where = null)
        {
            var query = $"select * from {_tableName} ";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var data = await conn.QueryAsync<T>(query);
                return data;
            }
        }
        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "ID" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }
    }
}
