using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using PhoneBook.Domain.Dtos;
using PhoneBook.Service.Contract;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Service.Features.EntryFeatures.Commands
{
    public class CreateEntryCommand : IRequest<bool>
    {
        public EntryDto EntryDto { get; set; }

        public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, bool>
        {
            private readonly IEntryService _entryService;
            private readonly IMapper _mapper;
            public CreateEntryCommandHandler(IEntryService entryService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _entryService = entryService ?? throw new ArgumentNullException(nameof(entryService));
            }
            public async Task<bool> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
            {
                var entry = _mapper.Map<Entry>(request.EntryDto);
                var entrySaved = false;
                if (entry != null)
                {
                    entrySaved = await _entryService.CreateEntryAsync(entry);
                }
                return entrySaved;
            }
        }
    }
}