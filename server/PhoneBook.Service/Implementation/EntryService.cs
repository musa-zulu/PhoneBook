using PhoneBook.Domain.Entities;
using PhoneBook.Persistence;
using PhoneBook.Service.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Service.Implementation
{
    public class EntryService : IEntryService
    {
        private readonly IApplicationDbContext _dataContext;

        public Task<bool> CreateEntryAsync(Entry entry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEntryAsync(Guid entryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entry>> GetEntriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Entry> GetEntryByIdAsync(Guid entryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntryAsync(Entry entryToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
