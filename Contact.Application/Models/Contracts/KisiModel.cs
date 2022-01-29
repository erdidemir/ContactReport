using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Models.Contracts
{
    public class KisiModel
    {
        public Guid Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Firma { get; set; }

    }
}
