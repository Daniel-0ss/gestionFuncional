using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RecetasService.Models;

public class GetRecetaByCodigoHandler : IRequestHandler<GetRecetaByCodigoQuery, RecetaDto>
{
    private readonly IRecetaRepository _repo;
    private readonly IMapper _mapper;

    public GetRecetaByCodigoHandler(IRecetaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public Task<RecetaDto> Handle(GetRecetaByCodigoQuery request, CancellationToken cancellationToken)
    {
        var receta = _repo.GetByCodigoUnico(request.CodigoUnico);
        return Task.FromResult(_mapper.Map<RecetaDto>(receta));
    }
}

