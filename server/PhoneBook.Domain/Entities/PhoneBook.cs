using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Domain.Entities
{
    public class PhoneBook : BaseEntity
    {
        [Key]
        public Guid PhoneBookDtoId { get; set; }
        public string Name { get; set; }
        public virtual List<Entry> Entries { get; set; }
    }
}
