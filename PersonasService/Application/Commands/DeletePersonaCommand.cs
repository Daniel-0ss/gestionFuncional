using MediatR;

namespace PersonasService.Application.Commands
{
    public class DeletePersonaCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoPersona { get; set; } // "Paciente" o "Medico"
    }
}

