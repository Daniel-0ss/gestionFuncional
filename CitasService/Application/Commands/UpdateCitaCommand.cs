using MediatR;
using System;
using CitasService.Models;

namespace CitasService.Application.Commands
{
    public class UpdateCitaCommand : IRequest<CitaDto>
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string Estado { get; set; } // "Pendiente", "En proceso", "Finalizada"
    }
}
