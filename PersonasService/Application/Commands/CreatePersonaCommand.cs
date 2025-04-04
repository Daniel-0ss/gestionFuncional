using MediatR;
using PersonasService.Models;

namespace PersonasService.Application.Commands
{
    public class CreatePersonaCommand : IRequest<PersonaDto>
    {
        public string Nombre { get; set; }
        public string TipoPersona { get; set; } // "Paciente" o "Medico"
    }
}
