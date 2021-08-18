using EFDAL.DB.DTOs;
using EntityFrameworkTemplate.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL.DB.Entities
{
    public class EFPerson : Entity
    {
        public EFPerson(EFPersonDto eFPersonDto)
        {
            Id = Guid.NewGuid();
            FirstName = eFPersonDto.FirstName;
            LastName = eFPersonDto.LastName;
            Age = eFPersonDto.Age;
            Address = eFPersonDto.Address;
            City = eFPersonDto.City;
            PhoneNumbers = eFPersonDto.PhoneNumbers.Select(x => new EFPhoneNumber { PhoneNumber = x.PhoneNumber, Id = Guid.NewGuid() }).ToList();
            FriendPhoneNumbers = eFPersonDto.FriendPhoneNumbers.Select(x => new EFFriendPhoneNumber { PhoneNumber = x.PhoneNumber, Id = Guid.NewGuid(), FriendName = x.FriendName }).ToList();
        }
        public EFPerson()
        {
            Id = Guid.NewGuid();

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public IList<EFPhoneNumber> PhoneNumbers { get; set; }
        public IList<EFFriendPhoneNumber> FriendPhoneNumbers { get; set; }
    }
}
