using Contact.Application.Features.Commands.Rapors.AddRapor;
using Contact.Application.Features.Queries.Contacts.GetKisiIletisimList;
using Contact.Application.Features.Queries.Rapors.GetRapor;
using Contact.Application.Features.Queries.Rapors.GetRaporList;
using Contact.Application.Models.Rapors;
using Contact.Domain.Enums.Contacts;
using EventBus.Messages.Commons;
using EventBus.Messages.Events;
using EventBus.Messages.Models;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var kisiIletisimList = await _mediator.Send(new GetKisiIletisimListQuery());
            var konumList = kisiIletisimList.Where(p => p.BilgiTipId == (int)BilgiTipEnum.Konum).Select(p => p.Deger).Distinct();
            var konumModelList = new List<KonumModel>();

            foreach (var item in konumList)
            {
                var KisiList = kisiIletisimList.Where(p => p.BilgiTipId == (int)BilgiTipEnum.Konum && p.Deger == item).Select(p => p.KisiId).ToList();

                KonumModel konumModel = new KonumModel();

                konumModel.Konum = item;
                konumModel.KisiSayisi = KisiList.Count();
                konumModel.TelefonNumarasiSayisi = kisiIletisimList.Where(p => KisiList.Contains(p.KisiId) && p.BilgiTipId == (int)BilgiTipEnum.TelefonNumarasi).Count();

                konumModelList.Add(konumModel);
            }


            // send create event to rabbitmq
            RaporCreateEvent eventMessage = new RaporCreateEvent();
            eventMessage.RaporId = raporId;
            eventMessage.KonumModelList = konumModelList;


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
