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
    public class KisiConfiguration : IEntityTypeConfiguration<Kisi>
    {
        public void Configure(EntityTypeBuilder<Kisi> entity)
        {
            entity.ToTable("Kisi");
            entity.HasKey(p => p.Id);

            entity.Property(x => x.Ad).IsRequired();
            entity.Property(x => x.Soyad).IsRequired();
            entity.Property(x => x.Firma).IsRequired();


            #region ForeingKey




            #endregion

            #region Index

            entity.HasIndex(e => new { e.Ad, e.Soyad }, "IX_Ad_Soyad");

            #endregion


        }
    }
}
