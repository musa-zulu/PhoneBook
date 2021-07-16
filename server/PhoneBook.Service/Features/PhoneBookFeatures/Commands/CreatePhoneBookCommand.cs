using MediatR;
using System;
using PhoneBook.Domain.Dtos;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;
using PhoneBook.Service.Contract;
using PhoneBookPoco = PhoneBook.Domain.Entities.PhoneBook;
using System.Collections.Generic;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Service.Features.PhoneBookFeatures.Commands
{
    public class CreatePhoneBookCommand : IRequest<bool>
    {
        public PhoneBookDto PhoneBookDto { get; set; }

        public class CreatePhoneBookCommandHandler : IRequestHandler<CreatePhoneBookCommand, bool>
        {
            private readonly IMapper _mapper;
            private readonly IPhoneBookService _phoneBookService;
            public CreatePhoneBookCommandHandler(IPhoneBookService phoneBookService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _phoneBookService = phoneBookService ?? throw new ArgumentNullException(nameof(phoneBookService));
            }
            public async Task<bool> Handle(CreatePhoneBookCommand request, CancellationToken cancellationToken)
            {
                var phoneBook = _mapper.Map<PhoneBookPoco>(request.PhoneBookDto);
                phoneBook.Entries = new List<Entry>();
                var isSaved = false;
                if (phoneBook != null)
                {
                    isSaved = await _phoneBookService.CreatePhoneBookAsync(phoneBook);
                }
                return isSaved;
            }
        }
    }
}