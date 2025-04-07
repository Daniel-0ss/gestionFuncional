using MediatR;
using System;
using CitasService.Models;

namespace CitasService.Application.Commands
{
    public class DeleteCitaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
    }
}
