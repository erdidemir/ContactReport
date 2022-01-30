using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Models.Contracts;
using Contact.Domain.Entities.Contacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.Queries.Contacts.GetKisiIletisimList
{
    public class GetKisiIletisimListByKisiIdQueryHandler : IRequestHandler<GetKisiIletisimListByKisiIdQuery, IList<KisiIletisimModel>>
    {
        private readonly IKisiIletisimRepository _kisiIletisimRepository;
        private readonly IMapper _mapper;
        public GetKisiIletisimListByKisiIdQueryHandler(IKisiIletisimRepository kisiIletisimRepository,
            IMapper mapper)
        {
            _kisiIletisimRepository = kisiIletisimRepository;
            _mapper = mapper;
        }
        public async Task<IList<KisiIletisimModel>> Handle(GetKisiIletisimListByKisiIdQuery request, CancellationToken cancellationToken)
        {
            var kisiIletisimList = await _kisiIletisimRepository.GetKisiIletisimListByKisiId(request.KisiId);

            return _mapper.Map<IList<KisiIletisimModel>>(kisiIletisimList);
        }
    }
}