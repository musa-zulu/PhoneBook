using MediatR;
using PhoneBook.Service.Contract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Service.Features.EntryFeatures.Commands
{
    public class DeleteEntryByIdCommand : IRequest<bool>
    {
        public Guid EntryId { get; set; }
        public class DeleteEntryByIdCommandHandler : IRequestHandler<DeleteEntryByIdCommand, bool>
        {
            private readonly IEntryService _entryService;
            public DeleteEntryByIdCommandHandler(IEntryService entryService)
            {
                _entryService = entryService;
            }
            public async Task<bool> Handle(DeleteEntryByIdCommand request, CancellationToken cancellationToken)
            {
                var results = await _entryService.DeleteEntryAsync(request.EntryId);
                return results;
            }
        }
    }
}