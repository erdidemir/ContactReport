using Contact.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Entities.Contacts
{
    public class BilgiTip: EntityBase
    {
        public BilgiTip()
        {
            KisiIletisims = new HashSet<KisiIletisim>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }

        public int BilgiTipEnumId { get; set; }

        public virtual ICollection<KisiIletisim> KisiIletisims { get; set; }

    }
}
