using MediatR;
using CitasService.Models;
using System;

namespace CitasService.Application.Commands
{
    public class UpdateCitaCommand : IRequest<CitaDto>
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public string Estado { get; set; } // "Pendiente", "En proceso", "Finalizada"
    }
}
