using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Rapors.AddRapor
{
    public class AddRaporCommand : IRequest<Guid>
    {
        public DateTime Tarih { get; set; }
    }
}

