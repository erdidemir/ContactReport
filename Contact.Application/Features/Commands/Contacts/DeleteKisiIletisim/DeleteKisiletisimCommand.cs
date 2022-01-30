using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Contacts.DeleteKisiIletisim
{
    public class DeleteKisiIletisimCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
