using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PersonasService.Domain.Entities;
using PersonasService.Domain.Interfaces;
using PersonasService.Models;

namespace PersonasService.Application.Commands
{
    public class CreatePersonaHandler : IRequestHandler<CreatePersonaCommand, PersonaDto>
    {
        private readonly IPersonaRepository _repo;
        private readonly IMapper _mapper;

        public CreatePersonaHandler(IPersonaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<PersonaDto> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = new Persona
            {
                Nombre = request.Nombre,
                TipoPersona = request.TipoPersona
            };

            _repo.Add(persona);
            // Mapeo de Persona a PersonaDto
            var dto = _mapper.Map<PersonaDto>(persona);

            return Task.FromResult(dto);
        }
    }
}
