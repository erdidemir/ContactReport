using AutoMapper;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<RaporUpdateConsumer> _logger;

        public RaporUpdateConsumer(IMediator mediator, IMapper mapper, ILogger<RaporUpdateConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<RaporUpdateEvent> context)
        {
            var message = context.Message;

            UpdateRaporCommand updateRaporCommand = new UpdateRaporCommand();
            updateRaporCommand.Id = message.RaporId;
            updateRaporCommand.RaporUrl = message.RaporUrl;

            await _mediator.Send(updateRaporCommand);

            _logger.LogInformation("Rapor updated successfully");
        }
    }
}
