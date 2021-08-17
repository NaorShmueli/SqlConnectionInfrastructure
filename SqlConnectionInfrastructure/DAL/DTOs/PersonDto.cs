using DAL.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class PersonDto
    {
        public PersonDto(string id, string firstName, string lastName, int age, string address, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            City = city;
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public IList<string> PhoneNumbers { get; set; }
        public IList<FriendPhoneNumber> FriendPhoneNumbers { get; set; }
    }
}
