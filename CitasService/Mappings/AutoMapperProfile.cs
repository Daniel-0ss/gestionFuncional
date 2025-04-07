using AutoMapper;
using CitasService.Domain.Entities;
using CitasService.Application.Commands;
using CitasService.Models;

namespace CitasService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cita, CitaDto>().ReverseMap();
            CreateMap<CreateCitaCommand, Cita>();
            CreateMap<UpdateCitaCommand, Cita>();
        }
    }
}
