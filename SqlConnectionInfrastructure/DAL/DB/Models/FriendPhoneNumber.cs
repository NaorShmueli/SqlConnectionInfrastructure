using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB.Models
{
    public class FriendPhoneNumber
    {
        public FriendPhoneNumber(string friendName, string phoneNumber)
        {
            FriendName = friendName;
            PhoneNumber = phoneNumber;
        }
        public string FriendName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
