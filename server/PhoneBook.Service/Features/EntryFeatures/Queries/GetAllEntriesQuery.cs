using MediatR;
using PhoneBook.Domain.Entities;
using PhoneBook.Service.Contract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Service.Features.EntryFeatures.Queries
{
    public class GetAllEntriesQuery : IRequest<IEnumerable<Entry>>
    {
        public class GetAllEntriesQueryHandler : IRequestHandler<GetAllEntriesQuery, IEnumerable<Entry>>
        {
            private readonly IEntryService _entryService;
            public GetAllEntriesQueryHandler(IEntryService entryService)
            {
                _entryService = entryService;
            }
            public async Task<IEnumerable<Entry>> Handle(GetAllEntriesQuery request, CancellationToken cancellationToken)
            {
                var entries = await _entryService.GetEntriesAsync();
                if (entries == null)
                {
                    return null;
                }
                return entries.AsReadOnly();
            }
        }
    }
}
