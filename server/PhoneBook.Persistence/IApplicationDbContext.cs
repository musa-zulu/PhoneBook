﻿using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Entities;
using System.Threading.Tasks;

namespace PhoneBook.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> Contacts { get; set; }        
        Task<int> SaveChangesAsync();
    }
}