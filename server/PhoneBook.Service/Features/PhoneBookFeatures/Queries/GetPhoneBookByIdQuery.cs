using MediatR;
using PhoneBook.Service.Contract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Service.Features.PhoneBookFeatures.Queries
{
    public class GetPhoneBookByIdQuery : IRequest<Domain.Entities.PhoneBook>
    {
        public Guid PhoneBookId { get; set; }
        public class GetFinderByIdQueryHandler : IRequestHandler<GetPhoneBookByIdQuery, Domain.Entities.PhoneBook>
        {            
            private readonly IPhoneBookService _phoneBookService;
            public GetFinderByIdQueryHandler(IPhoneBookService phoneBookService)
            {
                _phoneBookService = phoneBookService;
            }
            public async Task<Domain.Entities.PhoneBook> Handle(GetPhoneBookByIdQuery request, CancellationToken cancellationToken)
            {
                var phoneBook = _phoneBookService.GetPhoneBookByIdAsync(request.PhoneBookId);
                if (phoneBook == null) return null;
                return await phoneBook;
            }
        }
    }
}
