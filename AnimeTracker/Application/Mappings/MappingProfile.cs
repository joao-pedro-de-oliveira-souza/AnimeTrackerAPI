using AnimeTracker.Dtos;
using AnimeTracker.Entities;
using AutoMapper;

namespace AnimeTracker.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }

}