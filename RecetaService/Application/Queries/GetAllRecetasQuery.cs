using System.Collections.Generic;
using MediatR;
using RecetasService.Models;

public class GetAllRecetasQuery : IRequest<IEnumerable<RecetaDto>>{}

