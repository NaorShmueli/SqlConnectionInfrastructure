using AdoTemplate.Abstraction;
using DAL.DB;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Tests")]
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
