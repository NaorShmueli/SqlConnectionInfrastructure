using EntityFrameworkTemplate.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL.DB.Entities
{
    public class EFFriendPhoneNumber : Entity
    {
        public string FriendName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
