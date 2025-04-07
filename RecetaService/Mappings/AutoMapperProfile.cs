using AutoMapper;
using RecetasService.Domain.Entities;
using RecetasService.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Receta, RecetaDto>().ReverseMap();
        CreateMap<CreateRecetaCommand, Receta>();
        CreateMap<UpdateRecetaCommand, Receta>();
    }
}
