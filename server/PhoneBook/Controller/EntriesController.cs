using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Domain.Dtos;
using PhoneBook.Service.Features.EntryFeatures.Commands;
using PhoneBook.Service.Features.EntryFeatures.Queries;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Controller
{
    [ApiController]
    [Route("api/v{version:apiVersion}/entries")]
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
        public async Task<IActionResult> Create([FromBody] EntryDto entryDto)
        {
            CreateEntryCommand command = new()
            {
                EntryDto = entryDto
            };
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllEntriesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetEntryByIdQuery { EntryId = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EntryDto entryDto)
        {
            UpdateEntryCommand command = new()
            {
                EntryDto = entryDto
            };
            if (command.EntryDto.EntryId == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteEntryByIdCommand { EntryId = id }));
        }
    }
}
