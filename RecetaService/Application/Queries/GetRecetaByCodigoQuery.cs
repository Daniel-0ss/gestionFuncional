using MediatR;
using RecetasService.Models;

public class GetRecetaByCodigoQuery : IRequest<RecetaDto>
{
    public string CodigoUnico { get; set; }
}

