using AutoMapper;
using Entities.Domain.Users;
using Entities.Domain.Users.Dtos;

namespace Entities.Infrastructure.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap()
                .ForMember(x => x.DomainEvents, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
