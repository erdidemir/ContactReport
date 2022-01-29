using Contact.Domain.Entities.Rapors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Configurations.Rapors
{
    public class RaporConfiguration : IEntityTypeConfiguration<Rapor>
    {
        public void Configure(EntityTypeBuilder<Rapor> entity)
        {
            entity.ToTable("Rapor");
            entity.HasKey(p => p.Id);

            entity.Property(x => x.Tarih).IsRequired();
            entity.Property(x => x.RaporDurumEnumId).IsRequired();

            #region ForeingKey

            #endregion

            #region Index

            #endregion

        }
    }
}
