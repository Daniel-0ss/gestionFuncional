using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PersonasService.Domain.Entities;
using PersonasService.Models;
using System.Collections.Generic;

namespace PersonasService.Application.Commands
{
    public class UpdatePersonaHandler : IRequestHandler<UpdatePersonaCommand, PersonaDto>
    {
        private readonly IPersonaRepository _repo;
        private readonly IMapper _mapper;

        public UpdatePersonaHandler(IPersonaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<PersonaDto> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            // 1. Buscar entidad desde BD
            var persona = _repo.GetById(request.Id);
            if (persona == null)
                throw new KeyNotFoundException($"No se encontró ninguna persona con ID {request.Id}.");

            // 2. Actualizar valores con lo que viene en el request
            _mapper.Map(request, persona);
             
            // 3. Guardar los cambios
            _repo.Update(persona);

            // 4. Devolver el DTO actualizado
            var dto = _mapper.Map<PersonaDto>(persona);
            return Task.FromResult(dto);
        }

    }
}
