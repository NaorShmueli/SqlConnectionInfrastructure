using DAL.DB;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    internal static class ProcessPersonExtensions
    {
        internal static IEnumerable<PersonDto> CreateDtos(this IEnumerable<Person> personList)
        {
            var result = new List<PersonDto>();
            var personGroup = personList.GroupBy(x => x.Id).Select(x => new { PersonId = x.Key, RelatedData = x.ToList() });
            foreach (var group in personGroup)
            {
                var sharedData = group.RelatedData.FirstOrDefault();
                var current = new PersonDto(group.PersonId, sharedData.FirstName, sharedData.LastName, sharedData.Age, sharedData.Address, sharedData.City, group.RelatedData.Select(x => x.PhoneNumbers.FirstOrDefault()).ToList(), group.RelatedData.Select(x => x.FriendPhoneNumbers.FirstOrDefault()).ToList());
                result.Add(current);
            }
            return result;
        }
    }
}
