using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Domain.Entities.Contacts;
using Contact.Infrastructure.Contracts.Persistence;

namespace Kisiler.UnitTest.TestSetup
{
    public static class Kisiler
    {
        public static void AddKisiler(this ApplicationContext context)
        {
            context.Kisi.AddRange(new Kisi[]{
                new Kisi(){ Id = Guid.NewGuid(), Ad ="Ahmet", Soyad="mehmet", Firma="ABC" },
                new Kisi(){ Id = Guid.NewGuid(), Ad ="Ayşe", Soyad="Fatma", Firma="DEF" },
                new Kisi(){ Id = Guid.NewGuid(), Ad ="Turan", Soyad="Güneş", Firma="FGH" },
            });
        }
    }
}
