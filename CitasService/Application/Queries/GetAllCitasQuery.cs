using System.Collections.Generic;
using MediatR;
using CitasService.Models;

namespace CitasService.Application.Queries
{
    public class GetAllCitasQuery : IRequest<IEnumerable<CitaDto>> { }
}
