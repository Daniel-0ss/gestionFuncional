using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using CitasService.Application.Commands;
using CitasService.Application.Queries;
using System;

namespace CitasService.Controllers
{
    [RoutePrefix("api/citas")]
    public class CitaController : ApiController
    {
        private readonly IMediator _mediator;

        public CitaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var citas = await _mediator.Send(new GetAllCitasQuery());
            return Ok(citas);
        }

        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCitaByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create(CreateCitaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut, Route("")]
        public async Task<IHttpActionResult> Update(UpdateCitaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCitaCommand { Id = id });
            return Ok(result);
        }
    }
}
