using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Models
{
    public  class KonumModel
    {
        public string RaporId { get; set; }
        public string Konum { get; set; }
        public long KisiSayisi { get; set; }
        public long TelefonNumarasiSayisi { get; set; }
    }
}
