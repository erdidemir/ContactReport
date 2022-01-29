using Contact.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Configurations.Contacts
{
    public class BilgiTipConfiguration : IEntityTypeConfiguration<BilgiTip>
    {
        public void Configure(EntityTypeBuilder<BilgiTip> entity)
        {
            entity.ToTable("BilgiTip");
            entity.HasKey(p => p.Id);

            entity.Property(x => x.Ad).IsRequired();

            #region ForeingKey



            #endregion

            #region Index

            entity.HasIndex(e => new { e.Ad }, "IX_Ad");

            #endregion


        }
    }
}
