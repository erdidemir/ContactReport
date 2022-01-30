using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Contacts.AddKisiIletisim
{
    public class AddKisiIletisimCommand : IRequest<Guid>
    {
        public Guid KisiId { get; set; }
        public int BilgiTipId { get; set; }
        public string Deger { get; set; }
    }
}
