using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Models.Contracts
{
    public class KisiIletisimModel
    {
        public int KisiId { get; set; }
        public string KisiName { get; set; }
        public int BilgiTipId { get; set; }
        public string BilgiTipAd { get; set;}
        public string Deger { get; set; }
    }
}
