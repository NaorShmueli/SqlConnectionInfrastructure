using DAL.DB.SqlModels;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    internal static class PersonInitializationDataTableExtension
    {
        internal static void InitPerson(this DataTable dataTable, IEnumerable<PersonDto> persons)
        {
            dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
            dataTable.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("LastName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Age", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
            dataTable.Columns.Add(new DataColumn("City", typeof(string)));

            foreach (var person in persons)
            {
                var row = dataTable.NewRow();
                row["Id"] = person.Id;
                row["FirstName"] = person.FirstName;
                row["LastName"] = person.LastName;
                row["Age"] = person.Age;
                row["Address"] = person.Address;
                row["City"] = person.City;
                dataTable.Rows.Add(row);
            }

        }
    }
}
