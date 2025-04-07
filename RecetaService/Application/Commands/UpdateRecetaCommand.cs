using MediatR;
using RecetasService.Models;

public class UpdateRecetaCommand : IRequest<RecetaDto>, IBaseRequest
{
    public int Id { get; set; } // Add this property
    public string CodigoUnico { get; set; }
    public string Estado { get; set; }
}
