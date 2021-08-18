using DAL.DB.SqlModels;
using DAL.DTOs;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers
{
    public class PersonInitializationDataTable : IPersonInitializationDataTable
    {
        public DataTable InitPerson(IEnumerable<PersonDto> persons)
        {
            var dataTable = new DataTable();
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
            return dataTable;
        }
        public DataTable InitPhoneNumbers(IEnumerable<PersonDto> persons)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("PersonId", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PhoneNumber", typeof(string)));

            foreach (var person in persons)
            {
                foreach (var phoneNumber in person.PhoneNumbers)
                {
                    var row = dataTable.NewRow();
                    row["PersonId"] = person.Id;
                    row["PhoneNumber"] = phoneNumber;
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;

        }

        public DataTable InitFriendPhoneNumbers(IEnumerable<PersonDto> persons)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("PersonId", typeof(string)));
            dataTable.Columns.Add(new DataColumn("FriendName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PhoneNumber", typeof(string)));

            foreach (var person in persons)
            {
                foreach (var friend in person.FriendPhoneNumbers)
                {
                    var row = dataTable.NewRow();
                    row["PersonId"] = person.Id;
                    row["FriendName"] = friend.FriendName;
                    row["PhoneNumber"] = friend.PhoneNumber;
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;

        }
    }
}
