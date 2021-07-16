using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Domain.Dtos
{
    public class EntryDto : BaseEntity
    {
        public Guid EntryId { get; set; }
        public string Name { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public Guid PhoneBookDtoId { get; set; }
        public virtual PhoneBookDto PhoneBook { get; set; }
    }
}
