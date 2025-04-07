using AutoMapper;
using MediatR;
using RecetasService.Domain.Entities;
using RecetasService.Models;
using System.Threading.Tasks;
using System.Threading;
using System;

public class CreateRecetaHandler : IRequestHandler<CreateRecetaCommand, RecetaDto>
{
    private readonly IRecetaRepository _repo;
    private readonly IMapper _mapper;

    public CreateRecetaHandler(IRecetaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public Task<RecetaDto> Handle(CreateRecetaCommand request, CancellationToken cancellationToken)
    {
        var receta = new Receta
        {
            CodigoUnico = Guid.NewGuid().ToString(),
            PacienteId = request.PacienteId,
            Estado = "Activa",
            FechaCreacion = DateTime.Now
        };

        _repo.Add(receta);

        return Task.FromResult(_mapper.Map<RecetaDto>(receta));
    }
}
