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
        private readonly ILogger<EFPersonRepository> _logger;
        public EFPersonRepository(ILogger<EFPersonRepository> logger, PersonContext personContext, ILoggerFactory loggerFactory) : base(personContext, new Logger<EFPersonRepository>(loggerFactory))
        {
            _logger = logger;
            _context = personContext;
        }

        public async override Task<EFPerson> Update(EFPerson entity)
        {
            try
            {
                var removeOldPhone = _context.PhoneNumbers.Where(x => x.EFPersonId == entity.Id);
                var removeOldFriendPhone = _context.FriendPhoneNumbers.Where(x => x.EFPersonId == entity.Id);
                _context.PhoneNumbers.RemoveRange(removeOldPhone);
                _context.FriendPhoneNumbers.RemoveRange(removeOldFriendPhone);
                _context.PhoneNumbers.AddRange(entity.PhoneNumbers);
                _context.FriendPhoneNumbers.AddRange(entity.FriendPhoneNumbers);
                return await base.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed EFPerson entity with id  {entity.Id}");
                return default;
            }
            
        }
        public async override Task<EFPerson> Get(Guid id)
        {
            try
            {
                return await _context.Persons.Include(x => x.FriendPhoneNumbers).Include(x => x.PhoneNumbers).Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed Get EFPerson entity with id  {id}");
                return default;
            }
        }

        public override IEnumerable<EFPerson> GetAll()
        {
            try
            {
                return _context.Persons.Include(x => x.FriendPhoneNumbers).Include(x => x.PhoneNumbers).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed GetAll EFPersons entities");
                return default;
            }
        }

        public override bool Delete(EFPerson entity)
        {
            try
            {
                _context.PhoneNumbers.RemoveRange(entity.PhoneNumbers);
                _context.FriendPhoneNumbers.RemoveRange(entity.FriendPhoneNumbers);
                return base.Delete(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed Delete EFPersons entity with id = {entity.Id}");
                return default;
            }

        }
    }
}
