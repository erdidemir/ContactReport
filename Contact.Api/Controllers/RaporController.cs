using Contact.Application.Features.Queries.Rapors.GetRapor;
using Contact.Application.Features.Queries.Rapors.GetRaporList;
using Contact.Application.Models.Rapors;
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
        public RaporController(IMediator mediator)
        {
            _mediator = mediator;
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
