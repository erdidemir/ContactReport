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

namespace Contact.Application.Features.Queries.Rapors.GetRapor
{
    public class GetRaporByIdQueryHandler : IRequestHandler<GetRaporByIdQuery, RaporModel>
    {
        private readonly IRaporRepository _raporRepository;
        private readonly IMapper _mapper;
        public GetRaporByIdQueryHandler(IRaporRepository RaporRepository,
            IMapper mapper)
        {
            _raporRepository = RaporRepository;
            _mapper = mapper;
        }
        public async Task<RaporModel> Handle(GetRaporByIdQuery request, CancellationToken cancellationToken)
        {
            var raporEntity = await _raporRepository.GetByIdAsync(request.Id);

            return _mapper.Map<RaporModel>(raporEntity);
        }
    }
}
