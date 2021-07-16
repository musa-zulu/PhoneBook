using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Entities;
using System.Threading.Tasks;
using PhoneBookPoco = PhoneBook.Domain.Entities.PhoneBook;

namespace PhoneBook.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<PhoneBookPoco> PhoneBooks { get; set; }        
        DbSet<Entry> Entries { get; set; }        
        Task<int> SaveChangesAsync();
    }
}
