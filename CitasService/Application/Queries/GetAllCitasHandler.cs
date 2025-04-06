using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CitasService.Models;

namespace CitasService.Application.Queries
{
    public class GetAllCitasHandler : IRequestHandler<GetAllCitasQuery, IEnumerable<CitaDto>>
    {
        private readonly ICitaRepository _repo;
        private readonly IMapper _mapper;

        public GetAllCitasHandler(ICitaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<IEnumerable<CitaDto>> Handle(GetAllCitasQuery request, CancellationToken cancellationToken)
        {
            var citas = _repo.GetAll();
            return Task.FromResult(_mapper.Map<IEnumerable<CitaDto>>(citas));
        }
    }
}
