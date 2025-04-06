using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PersonasService.Models;

namespace PersonasService.Application.Queries
{
    public class GetPersonaByIdHandler : IRequestHandler<GetPersonaByIdQuery, PersonaDto>
    {
        private readonly IPersonaRepository _repo;
        private readonly IMapper _mapper;

        public GetPersonaByIdHandler(IPersonaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<PersonaDto> Handle(GetPersonaByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _repo.GetById(request.Id);
            var dto = _mapper.Map<PersonaDto>(entity);
            return Task.FromResult(dto);
        }
    }
}
