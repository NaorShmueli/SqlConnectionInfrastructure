using DAL.DB.SqlModels;
using DAL.DTOs;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Extensions;
namespace DAL
{
    public class DataAccessConnector : IDataAccessConnector
    {
        private readonly PersonAdoRepository _personAdoRepository;
        private readonly ILogger<DataAccessConnector> _logger;
        private readonly ISqlHelper _sqlHelper;
        private readonly IPersonInitializationDataTable _personInitializationDataTable;
        internal DataAccessConnector(ILogger<DataAccessConnector> logger, ILoggerFactory loggerFactory, IConfiguration configuration, ISqlHelper sqlHelper, IPersonInitializationDataTable personInitializationDataTable)
        {
            _sqlHelper = sqlHelper;
            _personInitializationDataTable = personInitializationDataTable;
            _logger = logger;
            _personAdoRepository = new PersonAdoRepository(new Logger<PersonAdoRepository>(loggerFactory), configuration);
        }
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
                var dtos = personList.CreateDtos();
                result = dtos.FirstOrDefault();
                if (result == null)
                {
                    _logger.LogWarning($"Person with id = {id} not found");

                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetPerson failed");
            }
            return result;
        }

        public async Task<IEnumerable<PersonDto>> GetPersons()
        {
            List<PersonDto> result = null;
            try
            {
                var sp = "dbo.GetPersons";
                var command = new SqlCommand(sp);
                var personList = await _personAdoRepository.ExecuteQueryAsync(command);
                var dtos = personList.CreateDtos();

                if (personList == null)
                {
                    _logger.LogWarning($"Person table empty");
                }
                return dtos;


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetPersons failed");
            }
            return result;
        }

        public async Task<int> UpsertPersons(IEnumerable<PersonDto> persons)
        {
            var result = 0;
            var parameters = new Dictionary<string, IList<SqlParameter>>();
            try
            {
                var sp = "dbo.UpsertPersons";
                var command = new SqlCommand();
                var upsertPersonsParameter = _sqlHelper.CreateStructuredParameter("dbo.PersonRow", "@personRows", persons, _personInitializationDataTable.InitPerson);
                parameters.Add(sp, new List<SqlParameter> { upsertPersonsParameter });

                var sp2 = "dbo.UpsertPhoneNumbers";
                var upsertPhoneNumbers = _sqlHelper.CreateStructuredParameter("dbo.PhoneNumberRow", "@phoneNumberRows", persons, _personInitializationDataTable.InitPhoneNumbers);
                parameters.Add(sp2, new List<SqlParameter> { upsertPhoneNumbers });

                var sp3 = "dbo.UpsertFriendPhoneNumbers";
                var upsertFriendPhoneNumbers = _sqlHelper.CreateStructuredParameter("dbo.FriendPhoneNumberRow", "@friendPhoneNumberRows", persons, _personInitializationDataTable.InitFriendPhoneNumbers);
                parameters.Add(sp3, new List<SqlParameter> { upsertFriendPhoneNumbers });
                result = await _personAdoRepository.ExecuteTransactionNonQueryAsync(command, parameters);
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
