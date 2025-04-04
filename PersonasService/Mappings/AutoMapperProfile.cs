using AutoMapper;
using PersonasService.Domain.Entities;
using PersonasService.Models;

namespace PersonasService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Persona, PersonaDto>().ReverseMap();
        }
    }
}