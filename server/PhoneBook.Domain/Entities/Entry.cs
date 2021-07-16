using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Domain.Entities
{
    public class Entry : BaseEntity
    {
        [Key]
        public Guid EntryId { get; set; }
        public string Name { get; set; }        
        public string PhoneNumber { get; set; }

        public Guid PhoneBookId { get; set; }
        public virtual PhoneBook PhoneBook { get; set; }
    }
}
