using DAL.DB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Comparer
{
    internal class FriendPhoneNumberEqualityComparer : IEqualityComparer<FriendPhoneNumber>
    {
        public bool Equals(FriendPhoneNumber x, FriendPhoneNumber y)
        {
            return x.FriendName == y.FriendName && x.PhoneNumber == y.PhoneNumber;
        }

        public int GetHashCode([DisallowNull] FriendPhoneNumber obj)
        {
            return obj.FriendName.GetHashCode() * obj.PhoneNumber.GetHashCode();
        }
    }
}
