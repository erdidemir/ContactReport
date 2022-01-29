﻿using Contact.Application.Features.Commands.Contacts.AddKisi;
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

        [HttpPost]
        public async Task<IActionResult> AddKisi(AddKisiCommand addKisiCommand)
        {
            var uuid = await _mediator.Send(addKisiCommand);

            return Ok(uuid);
        }
    }
}
