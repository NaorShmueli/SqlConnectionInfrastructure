using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB.SqlModels
{
    internal class PopulatePersonModel
    {
        internal PopulatePersonModel(SqlDataReader reader)
        {
            Id = reader.GetString(reader.GetOrdinal("Id"));
            FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            LastName = reader.GetString(reader.GetOrdinal("LastName"));
            Age = reader.GetInt32(reader.GetOrdinal("Age"));
            Address = reader.GetString(reader.GetOrdinal("Address"));
            City = reader.GetString(reader.GetOrdinal("City"));
            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            FriendPhoneName = reader.GetString(reader.GetOrdinal("FriendName"));
            FriendPhoneNumbers = reader.GetString(reader.GetOrdinal("FriendPhoneNumber"));
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string FriendPhoneName { get; set; }
        public string FriendPhoneNumbers { get; set; }
    }
}
