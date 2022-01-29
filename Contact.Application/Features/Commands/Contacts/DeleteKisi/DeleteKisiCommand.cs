using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Contacts.DeleteKisi
{
    public class DeleteKisiCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
