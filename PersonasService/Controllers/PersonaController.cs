using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using PersonasService.Application.Commands;
using PersonasService.Application.Queries;

namespace PersonasService.Controllers
{
    [RoutePrefix("api/personas")]
    public class PersonaController : ApiController
    {
        private readonly IMediator _mediator;

        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var personas = await _mediator.Send(new GetAllPersonasQuery());
            return Ok(personas);
        }

        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPersonaByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create(CreatePersonaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
