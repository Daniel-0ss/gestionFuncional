using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CitasService.Models;
using System.Collections.Generic;

namespace CitasService.Application.Commands
{
    public class UpdateCitaHandler : IRequestHandler<UpdateCitaCommand, CitaDto>
    {
        private readonly ICitaRepository _repo;
        private readonly IMapper _mapper;

        public UpdateCitaHandler(ICitaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<CitaDto> Handle(UpdateCitaCommand request, CancellationToken cancellationToken)
        {
            // 1. Buscar la cita existente
            var cita = _repo.GetById(request.Id);
            if (cita == null)
                throw new KeyNotFoundException($"No se encontró ninguna cita con ID {request.Id}.");

            // 2. Actualizar los valores con los del request
            _mapper.Map(request, cita);

            // 3. Guardar cambios
            _repo.Update(cita);

            // 4. Devolver el DTO actualizado
            var dto = _mapper.Map<CitaDto>(cita);
            return Task.FromResult(dto);
        }
    }
}
