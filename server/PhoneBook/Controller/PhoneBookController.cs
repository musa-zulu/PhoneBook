﻿using MediatR;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Service.Features.PhoneBookFeatures.Commands;
using PhoneBook.Service.Features.PhoneBookFeatures.Queries;

namespace PhoneBook.Controller
{
    [ApiController]
    [Route("api/v{version:apiVersion}/PhoneBooks")]
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
        public async Task<IActionResult> Create(CreatePhoneBookCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPhoneBooksQuery()));
        }
    }
}