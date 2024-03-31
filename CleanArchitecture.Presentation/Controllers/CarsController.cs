using CleanArchitecture.Application.Feature.Cars.Commands.Create;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class CarsController : ApiBaseController
    {
        public CarsController(IMediator mediator) : base(mediator) { }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCarCommand createCarCommand, CancellationToken cancellationToken)
        {
           MessageResponse response = await _mediator.Send(createCarCommand,cancellationToken);
           return Ok(response);
        }
    }

}
