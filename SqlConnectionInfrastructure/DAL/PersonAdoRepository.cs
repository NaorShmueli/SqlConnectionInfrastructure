using AdoTemplate.Abstraction;
using DAL.DB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class PersonAdoRepository : AdoRepository<Person>
    {
        private readonly ILogger<PersonAdoRepository> _logger;

        public PersonAdoRepository(ILogger<PersonAdoRepository> logger, IConfiguration configuration) 
            : base(configuration["SQL_CON_STRINGS"], logger)
        {
            _logger = logger;
        }
        protected override Person PopulateRecord(SqlDataReader reader)
        {
            try
            {
                return new Person(reader);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occur in PopulateRecord");
                return default;
            }
        }
    }
}
