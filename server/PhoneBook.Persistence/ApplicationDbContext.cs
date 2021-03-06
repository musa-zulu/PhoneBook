using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Entities;
using System.Threading.Tasks;
using PhoneBookPoco = PhoneBook.Domain.Entities.PhoneBook;

namespace PhoneBook.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<PhoneBookPoco> PhoneBooks { get; set; }     
        public DbSet<Entry> Entries { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("DataSource=app.db");
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
