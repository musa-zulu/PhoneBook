using MediatR;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Service.Features.PhoneBookFeatures.Commands;
using PhoneBook.Service.Features.PhoneBookFeatures.Queries;
using PhoneBook.Domain.Dtos;

namespace PhoneBook.Controller
{
    [ApiController]
    [Route("api/v{version:apiVersion}/phoneBooks")]
    [ApiVersion("1.0")]
    public class PhoneBookController : ControllerBase
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
        public async Task<IActionResult> Create([FromBody] PhoneBookDto phoneBookDto)
        {
            CreatePhoneBookCommand command = new()
            {
                PhoneBookDto = phoneBookDto
            };
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPhoneBooksQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetPhoneBookByIdQuery { PhoneBookId = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeletePhoneBookByIdCommand { PhoneBookId = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PhoneBookDto phoneBookDto)
        {
            UpdatePhoneBookCommand command = new()
            {
                PhoneBookDto = phoneBookDto
            };
            if (command.PhoneBookDto.PhoneBookId == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
