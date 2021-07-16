using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBookPoco = PhoneBook.Domain.Entities.PhoneBook;

namespace PhoneBook.Service.Contract
{
    public interface IPhoneBookService
    {
        Task<List<PhoneBookPoco>> GetPhoneBooksAsync();
        Task<bool> CreatePhoneBookAsync(PhoneBookPoco phoneBook);
        Task<PhoneBookPoco> GetPhoneBookByIdAsync(Guid phoneBookId);
        Task<bool> UpdatePhoneBookAsync(PhoneBookPoco phoneBookToUpdate);
        Task<bool> DeletePhoneBookAsync(Guid phoneBookId);
    }
}
