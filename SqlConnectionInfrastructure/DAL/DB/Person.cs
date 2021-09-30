using AdoTemplate.Abstraction.Interfaces;
using DAL.DB.Models;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Tests")]
namespace DAL.DB
{
    public class Person : IEntity
    {
        public Person(SqlDataReader reader)
        {
            Id = reader.GetString(reader.GetOrdinal("Id"));
            FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            LastName = reader.GetString(reader.GetOrdinal("LastName"));
            Age = reader.GetInt32(reader.GetOrdinal("Age"));
            Address = reader.GetString(reader.GetOrdinal("Address"));
            City = reader.GetString(reader.GetOrdinal("City"));
            PhoneNumbers = new List<string> { reader.GetString(reader.GetOrdinal("PhoneNumber")) };
            FriendPhoneNumbers = new List<FriendPhoneNumber>() { new FriendPhoneNumber(reader.GetString(reader.GetOrdinal("FriendName")), reader.GetString(reader.GetOrdinal("FriendPhoneNumber"))) };
        }
        public Person()
        {
            PhoneNumbers = new List<string>();
            FriendPhoneNumbers = new List<FriendPhoneNumber>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public IList<string> PhoneNumbers { get; set; }
        public IList<FriendPhoneNumber> FriendPhoneNumbers { get; set; }

        internal PersonDto ToDto()
        {
            return new PersonDto(Id, FirstName, LastName, Age, Address, City, PhoneNumbers, FriendPhoneNumbers);
        }
    }
}
