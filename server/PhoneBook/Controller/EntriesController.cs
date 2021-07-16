using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using PhoneBook.Service.Features.EntryFeatures.Commands;

namespace PhoneBook.Controller
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Entries")]
    [ApiVersion("1.0")]
    public class EntriesController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator
        {
            get { return _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); }
            set
            {
                if (_mediator != null) throw new InvalidOperationException("Mediator is already set");
                _mediator = value;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEntryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
