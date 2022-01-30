using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Domain.Entities.Rapors;
using Contact.Domain.Enums.Rapors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Rapors.AddRapor
{
    public class AddRaporCommandHandler : IRequestHandler<AddRaporCommand, Guid>
    {
        private readonly IRaporRepository _raporRepository;
        private readonly IMapper _mapper;


        public AddRaporCommandHandler(IRaporRepository raporRepository,
            IMapper mapper)
        {
            _raporRepository = raporRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddRaporCommand request, CancellationToken cancellationToken)
        {
            var raporEntity = _mapper.Map<Rapor>(request);

            raporEntity.Id = Guid.NewGuid();
            raporEntity.RaporDurumEnumId = (int)RaporDurumEnum.Hazirlaniyor;

            await _raporRepository.AddAsync(raporEntity);

            return raporEntity.Id;
        }
    }
}