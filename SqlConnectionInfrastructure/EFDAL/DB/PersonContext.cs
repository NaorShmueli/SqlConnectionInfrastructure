using EFDAL.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL.DB
{
    public class PersonContext : DbContext
    {
        public DbSet<EFPerson> Persons { get; set; }

        public DbSet<EFFriendPhoneNumber> FriendPhoneNumbers { get; set; }

        public DbSet<EFPhoneNumber> PhoneNumbers { get; set; }

        private readonly IConfiguration _configuration;
        public PersonContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["SQL_CON_STRINGS"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EFPerson>()
                .HasMany(p => p.PhoneNumbers).WithOne();
            modelBuilder.Entity<EFPerson>()
              .HasMany(p => p.FriendPhoneNumbers).WithOne();

            base.OnModelCreating(modelBuilder);
        }
    }
}
