using System;
using MediatR;
using CitasService.Models;

namespace CitasService.Application.Queries
{
    public class GetCitaByIdQuery : IRequest<CitaDto>
    {
        public Guid Id { get; set; }
    }
}
