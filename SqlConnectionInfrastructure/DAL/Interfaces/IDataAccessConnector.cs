using DAL.DB.SqlModels;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IDataAccessConnector
    {
        Task<int> UpsertPersons(IEnumerable<UpsertPersonModel> persons);
        Task<PersonDto> GetPerson(string id);
        Task<bool> DeletePerson(string id);
    }
}
