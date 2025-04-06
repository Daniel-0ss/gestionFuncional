using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CitasService.Domain.Entities;
using CitasService.Models;
using System;

namespace CitasService.Application.Commands
{
    public class CreateCitaHandler : IRequestHandler<CreateCitaCommand, CitaDto>
    {
        private readonly ICitaRepository _repo;
        private readonly IMapper _mapper;

        public CreateCitaHandler(ICitaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<CitaDto> Handle(CreateCitaCommand request, CancellationToken cancellationToken)
        {
            var cita = new Cita
            {
                Id = Guid.NewGuid(),
                Fecha = request.Fecha,
                Lugar = request.Lugar,
                PacienteId = request.PacienteId,
                MedicoId = request.MedicoId,
                Estado = "Pendiente"
            };

            _repo.Add(cita);

            var dto = _mapper.Map<CitaDto>(cita);

            return Task.FromResult(dto);
        }
    }
}
