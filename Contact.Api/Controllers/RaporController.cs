using Contact.Application.Features.Queries.Rapors.GetRapor;
using Contact.Application.Features.Queries.Rapors.GetRaporList;
using Contact.Application.Models.Rapors;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        public RaporController(IMediator mediator,
            IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRapor()
        {
            // send create event to rabbitmq
            RaporCreateEvent eventMessage = new RaporCreateEvent();

            await _publishEndpoint.Publish<RaporCreateEvent>(eventMessage);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRaporList()
        {
            return Ok(await _mediator.Send(new GetRaporListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RaporModel>> GetRaporById(Guid id)
        {
            var query = new GetRaporByIdQuery(id);

            return Ok(await _mediator.Send(query));

        }
    }
}
