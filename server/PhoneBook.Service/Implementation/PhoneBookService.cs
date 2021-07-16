using Microsoft.EntityFrameworkCore;
using PhoneBook.Persistence;
using PhoneBook.Service.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Service.Implementation
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IApplicationDbContext _dataContext;
        public PhoneBookService(IApplicationDbContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
        public async Task<bool> CreatePhoneBookAsync(Domain.Entities.PhoneBook phoneBook)
        {
            _dataContext.PhoneBooks.Add(phoneBook);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePhoneBookAsync(Guid phoneBookId)
        {
            var phoneBook = await GetPhoneBookByIdAsync(phoneBookId);

            if (phoneBook == null)
                return false;

            _dataContext.PhoneBooks.Remove(phoneBook);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Domain.Entities.PhoneBook> GetPhoneBookByIdAsync(Guid phoneBookId)
        {
            return await _dataContext.PhoneBooks
               .Include(c => c.Entries)
               .AsNoTracking()
               .SingleOrDefaultAsync(x => x.PhoneBookId == phoneBookId);
        }

        public async Task<List<Domain.Entities.PhoneBook>> GetPhoneBooksAsync()
        {
            return await _dataContext.PhoneBooks
               .Include(x => x.Entries)
               .AsNoTracking()
               .ToListAsync() ?? new List<Domain.Entities.PhoneBook>();
        }

        public async Task<bool> UpdatePhoneBookAsync(Domain.Entities.PhoneBook phoneBookToUpdate)
        {
            _dataContext.PhoneBooks.Update(phoneBookToUpdate);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
