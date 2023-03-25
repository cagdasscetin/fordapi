using AutoMapper;
using FordApi.Data;
using FordApi.Dto;

namespace FordApi.Service;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();
    }
}
