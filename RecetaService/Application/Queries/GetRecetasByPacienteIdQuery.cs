using System.Collections.Generic;
using MediatR;
using RecetasService.Models;

public class GetRecetasByPacienteIdQuery : IRequest<IEnumerable<RecetaDto>>
{
    public int PacienteId { get; set; }
}
