using EFDAL.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL.DB.EntityConfiguration
{
    internal class EFPersonConfiguration : IEntityTypeConfiguration<EFPerson>
    {
        public void Configure(EntityTypeBuilder<EFPerson> builder)
        {
            builder.HasMany(p => p.PhoneNumbers);
            builder.HasMany(p => p.FriendPhoneNumbers);
        }
    }
}
