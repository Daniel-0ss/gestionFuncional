using System.Web.Http;
using PersonasService.Application.Interfaces;
using PersonasService.Models;

namespace PersonasService.Controllers
{
    [RoutePrefix("api/personas")]
    public class PersonaController : ApiController
    {
        private readonly IPersonaService _service;

        public PersonaController(IPersonaService service)
        {
            _service = service;
        }

        [HttpGet, Route("")]
        public IHttpActionResult Get() => Ok(_service.GetAll());

        [HttpGet, Route("{id}")]
        public IHttpActionResult GetById(int id) => Ok(_service.GetById(id));

        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] PersonaDto dto)
        {
            _service.Create(dto);
            return Ok();
        }

        [HttpPut, Route("")]
        public IHttpActionResult Update([FromBody] PersonaDto dto)
        {
            _service.Update(dto);
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
