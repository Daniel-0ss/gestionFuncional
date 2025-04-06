using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PersonasService.Models;

namespace PersonasService.Application.Queries
{
    public class GetAllPersonasHandler : IRequestHandler<GetAllPersonasQuery, IEnumerable<PersonaDto>>
    {
        private readonly IPersonaRepository _repo;
        private readonly IMapper _mapper;

        public GetAllPersonasHandler(IPersonaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<IEnumerable<PersonaDto>> Handle(GetAllPersonasQuery request, CancellationToken cancellationToken)
        {
            var personas = _repo.GetAll();
            return Task.FromResult(_mapper.Map<IEnumerable<PersonaDto>>(personas));
        }
    }
}
