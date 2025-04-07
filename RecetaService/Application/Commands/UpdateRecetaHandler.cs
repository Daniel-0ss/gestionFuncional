using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

using RecetasService.Models;

public class UpdateRecetaHandler : IRequestHandler<UpdateRecetaCommand, RecetaDto>
{
    private readonly IRecetaRepository _repo;
    private readonly IMapper _mapper;

    public UpdateRecetaHandler(IRecetaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public Task<RecetaDto> Handle(UpdateRecetaCommand request, CancellationToken cancellationToken)
    {
        // 1. Buscar entidad en la base de datos
        var receta = _repo.GetById(request.Id);
        if (receta == null)
            throw new KeyNotFoundException($"No se encontró ninguna receta con ID {request.Id}.");
        // 2. Actualizar valores
        _mapper.Map(request, receta);

        // 3. Guardar cambios
        _repo.Update(receta);

        // 4. Mapear a DTO
        var dto = _mapper.Map<RecetaDto>(receta);
        return Task.FromResult(dto);
    }
}

