using Contact.Application.Models.Rapors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Queries.Rapors.GetRaporList
{
    public class GetRaporListQuery : IRequest<IList<RaporModel>>
    {
    }
}
