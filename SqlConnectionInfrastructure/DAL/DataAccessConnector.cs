using DAL.DB.SqlModels;
using DAL.DTOs;
using DAL.Extensions;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessConnector : IDataAccessConnector
    {
        private readonly PersonAdoRepository _personAdoRepository;
        private readonly ILogger<DataAccessConnector> _logger;
        public async Task<bool> DeletePerson(string id)
        {
            var result = false;
            try
            {
                var sp = "dbo.DeletePerson";
                var command = new SqlCommand(sp);
                command.Parameters.Add("@id",System.Data.SqlDbType.VarChar).Value = id;
                await _personAdoRepository.ExecuteNonQueryAsync(command);
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeletePerson failed");
            }
            return result;
        }

        public async Task<PersonDto> GetPerson(string id)
        {
            PersonDto result = null;
            try
            {
                var sp = "dbo.GetPerson";
                var command = new SqlCommand(sp);
                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
                var personList = await _personAdoRepository.ExecuteQueryAsync(command);
                var person = personList.FirstOrDefault();
                if (person != null)
                {
                    result = person.ToDto();
                }
                else
                {
                    _logger.LogWarning($"Person with id = {id} not found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetPerson failed");
            }
            return result;
        }

        public async Task<int> UpsertPersons(IEnumerable<UpsertPersonModel> persons)
        {
            var result = 0;
            try
            {
                var sp = "dbo.UpsertPersons";
                var tableType = "dbo.PersonRow";
                var command = new SqlCommand(sp);
                var dataTable = new DataTable();
                dataTable.InitPerson(persons);
                var param = command.Parameters.AddWithValue("@personRows", dataTable);
                param.TypeName = tableType;
                param.SqlDbType = SqlDbType.Structured;
                result = await _personAdoRepository.ExecuteNonQueryAsync(command);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpsertPersons failed");
            }
            return result;
        }
    }
}
