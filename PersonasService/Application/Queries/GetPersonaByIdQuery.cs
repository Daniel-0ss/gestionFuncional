using MediatR;
using PersonasService.Models;

namespace PersonasService.Application.Queries
{
    public class GetPersonaByIdQuery : IRequest<PersonaDto>
    {
        public int Id { get; set; }
    }
}
