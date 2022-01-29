using Contact.Application.Features.Commands.Contacts.AddKisi;
using Contact.Application.Features.Commands.Contacts.AddKisiIletisim;
using Contact.Application.Features.Commands.Contacts.DeleteKisi;
using Contact.Application.Features.Commands.Contacts.DeleteKisiIletisim;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
