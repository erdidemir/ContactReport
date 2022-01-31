using Contact.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Contracts.Persistence.Repositories.Commons
{
    public interface IApplicationContext
    {
        DbSet<Kisi> Kisi { get; set; }
        public DbSet<BilgiTip> BilgiTip { get; set; }
        public DbSet<KisiIletisim> KisiIletisim { get; set; }

        int SaveChanges();
    }
}
