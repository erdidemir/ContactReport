using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Application.Features.Commands.Rapors.UpdateRapor;
using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Contact.Api.EventBusConsumer
{
    public class RaporUpdateConsumer : IConsumer<RaporUpdateEvent>
    {
        //private readonly IMediator _mediator;
        //private readonly IMapper _mapper;

        //public RaporUpdateConsumer(IMediator mediator, IMapper mapper)
        //{
        //    _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        //}

        private readonly IRaporRepository _raporRepository;

        public RaporUpdateConsumer(IRaporRepository raporRepository)
        {
            _raporRepository = raporRepository;
        }

        public async Task Consume(ConsumeContext<RaporUpdateEvent> context)
        {
            var message = context.Message;

            var raporEntity = await _raporRepository.GetByIdAsync(message.RaporId);

            raporEntity.RaporUrl = message.RaporUrl;

            _raporRepository.UpdateAsync(raporEntity);

        }
    }
}
