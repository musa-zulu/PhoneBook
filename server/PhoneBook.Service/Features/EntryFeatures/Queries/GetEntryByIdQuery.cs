using MediatR;
using PhoneBook.Domain.Entities;
using PhoneBook.Service.Contract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Service.Features.EntryFeatures.Queries
{
    public class GetEntryByIdQuery : IRequest<Entry>
    {
        public Guid EntryId { get; set; }
        public class GetEntryByIdQueryHandler : IRequestHandler<GetEntryByIdQuery, Entry>
        {
            private readonly IEntryService _entryService;
            public GetEntryByIdQueryHandler(IEntryService entryService)
            {
                _entryService = entryService;
            }
            public async Task<Entry> Handle(GetEntryByIdQuery request, CancellationToken cancellationToken)
            {
                var entry = _entryService.GetEntryByIdAsync(request.EntryId);
                if (entry == null) return null;
                return await entry;
            }
        }
    }
}
