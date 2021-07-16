using AutoMapper;
using MediatR;
using PhoneBook.Domain.Dtos;
using PhoneBook.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Service.Features.PhoneBookFeatures.Commands
{
    public class UpdatePhoneBookCommand : IRequest<bool>
    {
        public PhoneBookDto PhoneBookDto { get; set; }

        public class UpdatePhoneBookCommandHandler : IRequestHandler<UpdatePhoneBookCommand, bool>
        {
            private readonly IMapper _mapper;
            private readonly IPhoneBookService _phoneBookService;
            public UpdatePhoneBookCommandHandler(IPhoneBookService phoneBookService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _phoneBookService = phoneBookService ?? throw new ArgumentNullException(nameof(phoneBookService));
            }
            public async Task<bool> Handle(UpdatePhoneBookCommand request, CancellationToken cancellationToken)
            {
                var phoneBook = _mapper.Map<PhoneBook.Domain.Entities.PhoneBook>(request.PhoneBookDto);
                var isSaved = false;
                if (phoneBook != null)
                {
                    isSaved = await _phoneBookService.UpdatePhoneBookAsync(phoneBook);
                }
                return isSaved;
            }
        }
    }
}