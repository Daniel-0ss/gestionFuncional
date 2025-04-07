using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RecetasService.Models;

public class GetRecetasByPacienteIdHandler : IRequestHandler<GetRecetasByPacienteIdQuery, IEnumerable<RecetaDto>>
{
    private readonly IRecetaRepository _repo;
    private readonly IMapper _mapper;

    public GetRecetasByPacienteIdHandler(IRecetaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public Task<IEnumerable<RecetaDto>> Handle(GetRecetasByPacienteIdQuery request, CancellationToken cancellationToken)
    {
        var recetas = _repo.GetByPacienteId(request.PacienteId);
        return Task.FromResult(_mapper.Map<IEnumerable<RecetaDto>>(recetas));
    }
}

