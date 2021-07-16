using System;
using System.Collections.Generic;

namespace PhoneBook.Domain.Dtos
{
    public class PhoneBookDto : BaseEntity
    {   
        public Guid PhoneBookDtoId { get; set; }
        public string Name { get; set; }
        public virtual List<EntryDto> EntryDtos { get; set; }
    }
}
