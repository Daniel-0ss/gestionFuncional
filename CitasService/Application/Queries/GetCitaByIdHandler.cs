using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CitasService.Models;
using System.Collections.Generic;

namespace CitasService.Application.Queries
{
    public class GetCitaByIdHandler : IRequestHandler<GetCitaByIdQuery, CitaDto>
    {
        private readonly ICitaRepository _repo;
        private readonly IMapper _mapper;

        public GetCitaByIdHandler(ICitaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<CitaDto> Handle(GetCitaByIdQuery request, CancellationToken cancellationToken)
        {
            var cita = _repo.GetById(request.Id);
            if (cita == null)
                throw new KeyNotFoundException($"No se encontró ninguna cita con ID {request.Id}.");

            var dto = _mapper.Map<CitaDto>(cita);
            return Task.FromResult(dto);
        }
    }
}
