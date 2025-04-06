using MediatR;
using CitasService.Models;
using System;

namespace CitasService.Application.Commands
{
    public class CreateCitaCommand : IRequest<CitaDto>
    {
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
    }
}
