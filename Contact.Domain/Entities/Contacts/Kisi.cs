using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Entities.Contacts
{
    public class Kisi
    {
        public Guid Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Firma { get; set; }

    }
}
