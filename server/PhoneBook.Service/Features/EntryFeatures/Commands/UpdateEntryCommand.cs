using AutoMapper;
using MediatR;
using PhoneBook.Domain.Dtos;
using PhoneBook.Domain.Entities;
using PhoneBook.Service.Contract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Service.Features.EntryFeatures.Commands
{
    public class UpdateEntryCommand : IRequest<bool>
    {
        public EntryDto EntryDto { get; set; }

        public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand, bool>
        {
            private readonly IEntryService _entryService;
            private readonly IMapper _mapper;
            public UpdateEntryCommandHandler(IEntryService entryService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _entryService = entryService ?? throw new ArgumentNullException(nameof(entryService));
            }
            public async Task<bool> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
            {
                var entry = _mapper.Map<Entry>(request.EntryDto);
                var isSaved = false;
                if (entry != null)
                {
                    isSaved = await _entryService.UpdateEntryAsync(entry);
                }
                return isSaved;
            }
        }
    }
}