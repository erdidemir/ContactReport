using Contact.Domain.Enums.Rapors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Models.Rapors
{
    public class RaporModel
    {
        public Guid Id { get; set; }

        public DateTime Tarih { get; set; }

        public int RaporDurumEnumId { get; set; }

        public string RaporDurumAd
        {
            get
            {
                switch (RaporDurumEnumId)
                {
                    case (int)RaporDurumEnum.Hazirlaniyor:
                        {
                            return "Hazırlanıyor";
                        }
                    case (int)RaporDurumEnum.Tamamlandı:
                        {
                            return "Tamamlandı";
                        }
                }

                return "";

            }
        }
        public string RaporUrl { get; set; }

        public byte[] RaporData
        {
            get
            {
                if(string.IsNullOrEmpty(RaporUrl) == true)
                    return null;

                return File.ReadAllBytes(RaporUrl);
            }
        }
    }
}
