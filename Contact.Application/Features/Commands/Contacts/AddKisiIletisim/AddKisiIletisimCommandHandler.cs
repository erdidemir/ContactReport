using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Features.Commands.Contacts.AddKisiIletisim;
using Contact.Domain.Entities.Contacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Contacts.AddKisiIletisimIletisim
{
    public class AddKisiIletisimCommandHandler : IRequestHandler<AddKisiIletisimCommand, Guid>
    {
        private readonly IKisiIletisimRepository _KisiIletisimRepository;
        private readonly IMapper _mapper;


        public AddKisiIletisimCommandHandler(IKisiIletisimRepository KisiIletisimRepository,
            IMapper mapper)
        {
            _KisiIletisimRepository = KisiIletisimRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddKisiIletisimCommand request, CancellationToken cancellationToken)
        {
            var KisiIletisimEntity = _mapper.Map<KisiIletisim>(request);

            KisiIletisimEntity.Id = Guid.NewGuid();

            await _KisiIletisimRepository.AddAsync(KisiIletisimEntity);

            return KisiIletisimEntity.Id;
        }
    }
}
