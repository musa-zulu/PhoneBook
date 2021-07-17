using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Domain.Entities
{
    public class Entry
    {
        [Key]
        public Guid EntryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public Guid PhoneBookId { get; set; }
        public virtual PhoneBook PhoneBook { get; set; }
    }
}
