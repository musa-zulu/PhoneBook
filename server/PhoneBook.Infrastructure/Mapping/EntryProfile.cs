using AutoMapper;
using PhoneBook.Domain.Dtos;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Infrastructure.Mapping
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<EntryDto, Entry>()
                .ForMember(dest => dest.PhoneBook, opt =>
                    opt.Ignore());                         
        }
    }
}
