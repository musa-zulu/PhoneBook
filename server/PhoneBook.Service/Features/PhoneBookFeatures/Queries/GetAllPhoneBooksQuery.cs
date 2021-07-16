using MediatR;
using PhoneBook.Service.Contract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Service.Features.PhoneBookFeatures.Queries
{
    public class GetAllPhoneBooksQuery : IRequest<IEnumerable<Domain.Entities.PhoneBook>>
        {
        public class GetAllPhoneBooksQueryHandler : IRequestHandler<GetAllPhoneBooksQuery, IEnumerable<Domain.Entities.PhoneBook>>
        {
            private readonly IPhoneBookService _phoneBookService;
            public GetAllPhoneBooksQueryHandler(IPhoneBookService phoneBookService)
            {
                _phoneBookService = phoneBookService;
            }
            public async Task<IEnumerable<Domain.Entities.PhoneBook>> Handle(GetAllPhoneBooksQuery request, CancellationToken cancellationToken)
            {
                var phoneBooks = await _phoneBookService.GetPhoneBooksAsync();
                if (phoneBooks == null)
                {
                    return null;
                }
                return phoneBooks.AsReadOnly();
            }
        }
    }
}
