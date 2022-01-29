using Contact.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Entities.Rapors
{
    public class Rapor : EntityBase
    {
        public Guid Id { get; set; }

        public DateTime Tarih { get; set; }

        public int RaporDurumEnumId { get; set; }

        public string RaporUrl { get; set; }
    }
}
