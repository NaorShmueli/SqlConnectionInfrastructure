using AdoTemplate.Abstraction.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoTemplate.Abstraction
{
    public abstract class AdoRepository<T> where T : IEntity
    {
        protected readonly string _connectionStrings;
        private readonly ILogger<AdoRepository<T>> _logger;

        public AdoRepository(string connectionStrings, ILogger<AdoRepository<T>> logger)
        {
            _logger = logger;
            _connectionStrings = connectionStrings;
        }
        public async virtual Task<int> ExecuteNonQueryAsync(SqlCommand command)
        {
            await using var con = new SqlConnection(_connectionStrings);
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();
            try
            {
                var rowEffected = await command.ExecuteNonQueryAsync();

                return rowEffected;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occur in ExecuteNonQueryAsync");
                return default;
            }
        }
        public async virtual Task<IEnumerable<T>> ExecuteQueryAsync(SqlCommand command)
        {
            var list = new List<T>();
            await using var con = new SqlConnection(_connectionStrings);

            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();
            try
            {
                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    var record = PopulateRecord(reader);
                    if (record != null)
                    {
                        list.Add(record);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occur in ExecuteQueryAsync");
                return default;
            }
            return list;
        }
        protected abstract T PopulateRecord(SqlDataReader reader);

    }
}
