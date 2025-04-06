using MediatR;
using PersonasService.Models;

public class UpdatePersonaCommand : IRequest<PersonaDto>
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string TipoPersona { get; set; }
}
