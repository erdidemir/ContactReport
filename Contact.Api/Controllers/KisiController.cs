using Contact.Application.Features.Commands.Contacts.AddKisi;
using Contact.Application.Features.Commands.Contacts.DeleteKisi;
using Contact.Application.Features.Commands.Contacts.DeleteKisiIletisim;
using Contact.Application.Features.Queries.Contacts.GetKisiList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Contact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        public readonly IMediator _mediator;
        public KisiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetKisiList()
        {
            return Ok(await _mediator.Send(new GetKisiListQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddKisi(AddKisiCommand addKisiCommand)
        {
            var uuid = await _mediator.Send(addKisiCommand);

            return Ok(uuid);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteKisi(DeleteKisiIletisimCommand addKisiCommand)
        {
             var unit = await _mediator.Send(addKisiCommand);

            return Ok();
        }
    }
}
