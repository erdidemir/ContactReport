using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Models.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.Queries.Contacts.GetKisiList
{
    public class GetKisiListQueryHandler : IRequestHandler<GetKisiListQuery, IList<KisiModel>>
    {
        private readonly IKisiRepository _KisiRepository;
        private readonly IMapper _mapper;
        public GetKisiListQueryHandler(IKisiRepository KisiRepository,
            IMapper mapper)
        {
            _KisiRepository = KisiRepository;
            _mapper = mapper;
        }
        public async Task<IList<KisiModel>> Handle(GetKisiListQuery request, CancellationToken cancellationToken)
        {
            var compaines = await _KisiRepository.GetAllAsync();

            return _mapper.Map<IList<KisiModel>>(compaines);
        }
    }
}
