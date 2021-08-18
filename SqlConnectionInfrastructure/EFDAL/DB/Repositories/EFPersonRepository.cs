using EFDAL.DB.Entities;
using EntityFrameworkTemplate.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL.DB.Repositories
{
    public class EFPersonRepository : GenericRepository<EFPerson>
    {
        private readonly PersonContext _context;
        public EFPersonRepository(PersonContext personContext, ILoggerFactory loggerFactory) : base(personContext, new Logger<EFPersonRepository>(loggerFactory))
        {
            _context = personContext;

        }

        public async override Task<EFPerson> Update(EFPerson entity)
        {
            var updatedEntity = _context.Persons.Include(x => x.FriendPhoneNumbers).Include(x => x.PhoneNumbers).FirstOrDefault(x => x.Id == entity.Id);
            updatedEntity.FirstName = entity.FirstName;
            updatedEntity.LastName = entity.LastName;
            updatedEntity.Age = entity.Age;
            updatedEntity.Address = entity.Address;
            updatedEntity.City = entity.City;
            updatedEntity.PhoneNumbers = entity.PhoneNumbers;
            updatedEntity.FriendPhoneNumbers = entity.FriendPhoneNumbers;
            //_context.Entry(updatedEntity).State = EntityState.Modified;
            return await base.Update(updatedEntity);
        }
        public async override Task<EFPerson> Get(Guid id)
        {
            return await _context.Persons.Include(x => x.FriendPhoneNumbers).Include(x => x.PhoneNumbers).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public override IEnumerable<EFPerson> GetAll()
        {
            return _context.Persons.Include(x => x.FriendPhoneNumbers).Include(x => x.PhoneNumbers).ToList();
        }

        public override bool Delete(EFPerson entity)
        {
            _context.PhoneNumbers.RemoveRange(entity.PhoneNumbers);
            _context.FriendPhoneNumbers.RemoveRange(entity.FriendPhoneNumbers);
            return base.Delete(entity);
        }
    }
}
