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
    public class KisiIletisimConfiguration : IEntityTypeConfiguration<KisiIletisim>
    {
        public void Configure(EntityTypeBuilder<KisiIletisim> entity)
        {
            entity.ToTable("KisiIletisim");
            entity.HasKey(p => p.Id);

            entity.Property(x => x.KisiId).IsRequired();
            entity.Property(x => x.BilgiTip).IsRequired();
            entity.Property(x => x.Deger).IsRequired();


            #region ForeingKey

            entity.HasOne(d => d.Kisi)
                   .WithMany(p => p.KisiIletisims)
                   .HasForeignKey(d => d.KisiId)
                   .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.BilgiTip)
                 .WithMany(p => p.KisiIletisims)
                 .HasForeignKey(d => d.BilgiTipId)
                 .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Index

            entity.HasIndex(e => new { e.BilgiTipId, e.KisiId    }, "UIX_BilgiTipId_KisiId").IsUnique();

            #endregion


        }
    }
}
