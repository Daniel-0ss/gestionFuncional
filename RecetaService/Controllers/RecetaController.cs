using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

[RoutePrefix("api/recetas")]
public class RecetasController : ApiController
{
    private readonly IMediator _mediator;

    public RecetasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost, Route("")]
    public async Task<IHttpActionResult> Crear(CreateRecetaCommand command)
    {
        var receta = await _mediator.Send(command);
        return Ok(receta);
    }

    [HttpPut, Route("estado")]
    public async Task<IHttpActionResult> ActualizarEstado(UpdateRecetaCommand command)
    {
        var receta = await _mediator.Send(command);
        return Ok(receta);
    }

    [HttpGet, Route("codigo/{codigo}")]
    public async Task<IHttpActionResult> ObtenerPorCodigo(string codigo)
    {
        var receta = await _mediator.Send(new GetRecetaByCodigoQuery { CodigoUnico = codigo });
        return Ok(receta);
    }

    [HttpGet, Route("paciente/{pacienteId}")]
    public async Task<IHttpActionResult> ObtenerPorPaciente(int pacienteId)
    {
        var recetas = await _mediator.Send(new GetRecetasByPacienteIdQuery { PacienteId = pacienteId });
        return Ok(recetas);
    }
}
