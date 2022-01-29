using Contact.Application.Features.Commands.Rapors.AddRapor;
using Contact.Application.Features.Queries.Rapors.GetRapor;
using Contact.Application.Features.Queries.Rapors.GetRaporList;
using Contact.Application.Models.Rapors;
using EventBus.Messages.Commons;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Contact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        public readonly IMediator _mediator;
        public RaporController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRapor()
        {
            AddRaporCommand addRaporCommand = new AddRaporCommand();

            addRaporCommand.Tarih = DateTime.Now;

            var raporId = await _mediator.Send(addRaporCommand);

            // send create event to rabbitmq
            RaporCreateEvent eventMessage = new RaporCreateEvent();
            eventMessage.RaporId = raporId;
            eventMessage.KonumList = new System.Collections.Generic.List<string> { "Ankara" };
            eventMessage.KisiSayisi = 10;
            eventMessage.TelefonNumarasiSayisi = 50;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var connection = factory.CreateConnection();

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: EventBusConstants.RaporCreateQueue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var message = JsonSerializer.Serialize(eventMessage);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: EventBusConstants.RaporCreateQueue,
                    basicProperties: null,
                    body: body
                );

                return Ok();
            }
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
