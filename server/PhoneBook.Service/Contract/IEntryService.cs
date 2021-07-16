using PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Service.Contract
{
    public interface IEntryService
    {
        Task<List<Entry>> GetEntriesAsync();
        Task<bool> CreateEntryAsync(Entry entry);
        Task<Entry> GetEntryByIdAsync(Guid entryId);
        Task<bool> UpdateEntryAsync(Entry entryToUpdate);
        Task<bool> DeleteEntryAsync(Guid entryId);
    }
}
