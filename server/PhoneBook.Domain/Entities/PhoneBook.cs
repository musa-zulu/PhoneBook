using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PhoneBook.Domain.Entities
{
    public class PhoneBook
    {
        [Key]
        public Guid PhoneBookId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Entry> Entries { get; set; }
    }
}
