using Contact.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Entities.Contacts
{
    public class KisiIletisim: EntityBase
    {
        public Guid Id { get; set; } 
        public Guid KisiId { get; set; }
        public int BilgiTipId { get; set; }
        public string Deger { get; set; }

        public virtual Kisi Kisi { get; set; }
        public virtual BilgiTip BilgiTip { get; set; }
    }
}
