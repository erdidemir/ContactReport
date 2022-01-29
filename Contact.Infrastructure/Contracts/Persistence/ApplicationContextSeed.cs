using Contact.Domain.Entities.Contacts;
using Contact.Domain.Enums.Contacts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Contracts.Persistence
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationContext applicationContext, ILogger<ApplicationContextSeed> logger)
        {
            if (applicationContext.BilgiTip.Count() == 0)
            {
                applicationContext.BilgiTip.AddRange(
                    new List<BilgiTip>() {
                         new BilgiTip() { Ad = "Telefon Numarası", BilgiTipEnumId=(int)BilgiTipEnum.TelefonNumarasi},
                         new BilgiTip() { Ad="E-mail Adresi" ,BilgiTipEnumId=(int)BilgiTipEnum.Email},
                         new BilgiTip() { Ad="Konum", BilgiTipEnumId=(int)BilgiTipEnum.Konum },
                    }
                    );

                applicationContext.SaveChanges();
            }
        }
    }
}
