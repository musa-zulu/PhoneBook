using Microsoft.EntityFrameworkCore;
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
        public EntryService(IApplicationDbContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<bool> CreateEntryAsync(Entry entry)
        {
            _dataContext.Entries.Add(entry);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEntryAsync(Guid entryId)
        {
            var entry = await GetEntryByIdAsync(entryId);

            if (entry == null)
                return false;

            _dataContext.Entries.Remove(entry);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Entry>> GetEntriesAsync()
        {
            return await _dataContext.Entries
               .Include(x => x.PhoneBook)
               .ToListAsync() ?? new List<Entry>();
        }

        public async Task<Entry> GetEntryByIdAsync(Guid entryId)
        {
            return await _dataContext.Entries
               .Include(c => c.PhoneBook)
               .AsNoTracking()
               .SingleOrDefaultAsync(x => x.EntryId == entryId);
        }

        public async Task<bool> UpdateEntryAsync(Entry entryToUpdate)
        {
            _dataContext.Entries.Update(entryToUpdate);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
