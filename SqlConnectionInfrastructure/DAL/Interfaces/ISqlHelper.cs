using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISqlHelper
    {
        public SqlParameter CreateStructuredParameter(string tableType, string parameterName, IEnumerable<PersonDto> persons, Func<IEnumerable<PersonDto>, DataTable> initializationDataTable);
    }
}
