using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Rapors.UpdateRapor
{
    public class UpdateRaporCommand : IRequest
    {
        public Guid Id { get; set; }
        public string RaporUrl { get; set; }
    }
}
