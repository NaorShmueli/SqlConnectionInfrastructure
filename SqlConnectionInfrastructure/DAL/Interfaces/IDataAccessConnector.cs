using DAL.DB.SqlModels;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDataAccessConnector
    {
        Task<int> UpsertPersons(IEnumerable<PersonDto> persons);
        Task<PersonDto> GetPerson(string id);
        Task<IEnumerable<PersonDto>> GetPersons();
        Task<bool> DeletePerson(string id);
    }
}
