using Contact.Application.Models.Rapors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Queries.Rapors.GetRapor
{
    public class GetRaporByIdQuery : IRequest<RaporModel>
    {
        public Guid Id { get; set; }

        public GetRaporByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}