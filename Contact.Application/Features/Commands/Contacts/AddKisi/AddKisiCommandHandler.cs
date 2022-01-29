using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Domain.Entities.Contacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Contacts.AddKisi
{
    public class AddKisiCommandHandler : IRequestHandler<AddKisiCommand, Guid>
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMapper _mapper;


        public AddKisiCommandHandler(IKisiRepository kisiRepository,
            IMapper mapper)
        {
            _kisiRepository = kisiRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddKisiCommand request, CancellationToken cancellationToken)
        {
            var kisiEntity = _mapper.Map<Kisi>(request);

            kisiEntity.Id = Guid.NewGuid();

            await _kisiRepository.AddAsync(kisiEntity);    

            return kisiEntity.Id;
        }
    }
}
