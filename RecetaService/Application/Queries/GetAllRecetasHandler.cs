using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RecetasService.Models;

public class GetAllRecetasHandler : IRequestHandler<GetAllRecetasQuery, IEnumerable<RecetaDto>>
{
    private readonly IRecetaRepository _repository;
    private readonly IMapper _mapper;

    public GetAllRecetasHandler(IRecetaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<IEnumerable<RecetaDto>> Handle(GetAllRecetasQuery request, CancellationToken cancellationToken)
    {
        var recetas = _repository.GetAll();
        var recetaDtos = _mapper.Map<IEnumerable<RecetaDto>>(recetas);
        return Task.FromResult(recetaDtos);
    }
}

