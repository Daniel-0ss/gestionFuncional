using MediatR;
using System;
using CitasService.Models;


namespace CitasService.Application.Commands
{
    public class CreateCitaCommand : IRequest<CitaDto>
    {
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
    }
}
