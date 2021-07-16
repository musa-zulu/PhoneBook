using AutoMapper;
using PhoneBook.Domain.Dtos;
using PhoneBookPoco = PhoneBook.Domain.Entities.PhoneBook;

namespace PhoneBook.Infrastructure.Mapping
{
    public class PhoneBookProfile : Profile
    {
        public PhoneBookProfile()
        {
            CreateMap<PhoneBookDto, PhoneBookPoco>()
                .ForMember(dest => dest.Entries, opt =>
                    opt.Ignore());                
        }
    }
}
