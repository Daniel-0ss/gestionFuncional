using MediatR;
using RecetasService.Models;
using System;

public class CreateRecetaCommand : IRequest<RecetaDto>
{
    public int Id { get; set; }
    public string CodigoUnico { get; set; }
    public int PacienteId { get; set; }
    public string Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
}
