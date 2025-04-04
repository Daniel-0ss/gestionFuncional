using System.Collections.Generic;
using MediatR;
using PersonasService.Models;

namespace PersonasService.Application.Queries
{
    public class GetAllPersonasQuery : IRequest<IEnumerable<PersonaDto>> { }
}