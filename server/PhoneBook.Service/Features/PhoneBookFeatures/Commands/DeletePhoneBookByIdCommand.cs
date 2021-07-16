using MediatR;
using PhoneBook.Service.Contract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Service.Features.PhoneBookFeatures.Commands
{
    public class DeletePhoneBookByIdCommand : IRequest<bool>
    {
        public Guid PhoneBookId { get; set; }
        public class DeletePhoneBookByIdHandler : IRequestHandler<DeletePhoneBookByIdCommand, bool>
        {
            private readonly IPhoneBookService _phoneBookService;
            public DeletePhoneBookByIdHandler(IPhoneBookService phoneBookService)
            {
                _phoneBookService = phoneBookService;
            }
            public async Task<bool> Handle(DeletePhoneBookByIdCommand request, CancellationToken cancellationToken)
            {
                var results = await _phoneBookService.DeletePhoneBookAsync(request.PhoneBookId);
                return results;
            }
        }
    }
}