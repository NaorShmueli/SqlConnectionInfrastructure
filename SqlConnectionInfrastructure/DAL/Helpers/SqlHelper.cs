using DAL.DTOs;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers
{
    public class SqlHelper : ISqlHelper
    {
        public SqlParameter CreateStructuredParameter(string tableType,string parameterName, IEnumerable<PersonDto> persons, Func<IEnumerable<PersonDto>,DataTable> initializationDataTable)
        {
            var dataTable = initializationDataTable.Invoke(persons);
            var param = new SqlParameter(parameterName, dataTable);
            param.TypeName = tableType;
            param.SqlDbType = SqlDbType.Structured;
            return param;
        }
    }
}
