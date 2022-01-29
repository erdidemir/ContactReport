using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Application.Models.Rapors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.Queries.Rapors.GetRaporList
{
    public class GetRaporListQueryHandler : IRequestHandler<GetRaporListQuery, IList<RaporModel>>
    {
        private readonly IRaporRepository _RaporRepository;
        private readonly IMapper _mapper;
        public GetRaporListQueryHandler(IRaporRepository RaporRepository,
            IMapper mapper)
        {
            _RaporRepository = RaporRepository;
            _mapper = mapper;
        }
        public async Task<IList<RaporModel>> Handle(GetRaporListQuery request, CancellationToken cancellationToken)
        {
            var compaines = await _RaporRepository.GetAllAsync();

            return _mapper.Map<IList<RaporModel>>(compaines);
        }
    }
}
