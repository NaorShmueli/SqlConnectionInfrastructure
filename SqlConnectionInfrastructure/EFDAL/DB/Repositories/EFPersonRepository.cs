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
            try
            {
                //_context.PhoneNumbers.RemoveRange(_context.PhoneNumbers.AsNoTracking().Where(x => x.EFPersonId == entity.Id));
                //_context.FriendPhoneNumbers.RemoveRange(_context.FriendPhoneNumbers.AsNoTracking().Where(x => x.EFPersonId == entity.Id));
                return await base.Update(entity);
            }
            catch (Exception ex)
            {
                return default;
            }
            
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
