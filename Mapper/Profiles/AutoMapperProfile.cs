using AutoMapper;
using OnlineStore.Models;

namespace OnlineStore.Mapper.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
