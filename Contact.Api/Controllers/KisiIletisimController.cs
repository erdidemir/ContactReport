using Contact.Application.Features.Commands.Contacts.AddKisiIletisim;
using Contact.Application.Features.Commands.Contacts.DeleteKisiIletisim;
using Contact.Application.Features.Queries.Contacts.GetKisiIletisimList;
using Contact.Application.Features.Queries.Contacts.GetKisiList;
using Contact.Application.Models.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Contact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiIletisimController : ControllerBase
    {
        public readonly IMediator _mediator;
        public KisiIletisimController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{kisiId}")]
        public async Task<ActionResult<IList<KisiIletisimModel>>> GetKisiIletisimListByKisiId(Guid kisiId)
        {
            var query = new GetKisiIletisimListByKisiIdQuery(kisiId);

            return Ok(await _mediator.Send(query));

        }

        [HttpPost]
        public async Task<IActionResult> AddKisiIletisim(AddKisiIletisimCommand addKisiIletisimCommand)
        {
            var uuid = await _mediator.Send(addKisiIletisimCommand);

            return Ok(uuid);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteKisiIletisim(DeleteKisiIletisimCommand addKisiIletisimCommand)
        {
            var unit = await _mediator.Send(addKisiIletisimCommand);

            return Ok();
        }
    }
}
