using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL.DB.DTOs
{
    public class EFPersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public IList<EFPhoneNumberDto> PhoneNumbers { get; set; }
        public IList<EFFriendPhoneNumberDto> FriendPhoneNumbers { get; set; }
    }
}
