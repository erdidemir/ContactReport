using Contact.Application.Contracts.Persistence.Repositories.Commons;
using Contact.Domain.Configurations.Contacts;
using Contact.Domain.Configurations.Rapors;
using Contact.Domain.Entities.Contacts;
using Contact.Domain.Entities.Rapors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Contracts.Persistence
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
            //foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Added:
            //            entry.Entity.CreatedDate = DateTime.Now;
            //            break;
            //        case EntityState.Modified:
            //            entry.Entity.LastModifiedDate = DateTime.Now;
            //            break;
            //    }
            //}
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contacts

            modelBuilder.ApplyConfiguration(new KisiConfiguration());
            modelBuilder.ApplyConfiguration(new BilgiTipConfiguration());
            modelBuilder.ApplyConfiguration(new KisiIletisimConfiguration());

            #endregion

            #region Rapors

            modelBuilder.ApplyConfiguration(new RaporConfiguration());

            #endregion

            foreach (var e in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var fk in e.GetForeignKeys())
                {
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }

        #region Contacts

        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<BilgiTip> BilgiTip { get; set; }
        public DbSet<KisiIletisim> KisiIletisim { get; set; }


        #endregion

        #region Rapors

        public DbSet<Rapor> Rapor { get; set; }

        #endregion

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
