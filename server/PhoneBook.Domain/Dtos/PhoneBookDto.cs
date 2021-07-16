using System;

namespace PhoneBook.Domain.Dtos
{
    public class PhoneBookDto : BaseEntity
    {   
        public Guid PhoneBookId { get; set; }
        public string Name { get; set; }        
    }
}
