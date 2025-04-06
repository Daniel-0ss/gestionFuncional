using MediatR;
using System;

namespace CitasService.Application.Commands
{
    public class DeleteCitaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
    }
}
