using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Domain.Dtos
{
    public class EntryDto : BaseEntity
    {
        public Guid EntryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        public Guid PhoneBookId { get; set; }
    }
}
