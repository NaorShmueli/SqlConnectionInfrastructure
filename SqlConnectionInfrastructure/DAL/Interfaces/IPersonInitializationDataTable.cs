using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPersonInitializationDataTable
    {
        DataTable InitPerson(IEnumerable<PersonDto> persons);
        DataTable InitPhoneNumbers(IEnumerable<PersonDto> persons);
        DataTable InitFriendPhoneNumbers(IEnumerable<PersonDto> persons);
    }
}
