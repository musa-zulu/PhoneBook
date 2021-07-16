using System;

namespace PhoneBook.Domain
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
