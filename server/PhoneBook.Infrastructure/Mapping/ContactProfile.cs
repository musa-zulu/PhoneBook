using AutoMapper;
using PhoneBook.Domain.Dtos;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Infrastructure.Mapping
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDto, Contact>()
                .ReverseMap();
        }
    }
}
