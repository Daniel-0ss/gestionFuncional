using System.Collections.Generic;
using AutoMapper;
using RecetasService.Domain.Entities;
using RecetasService.Models;


public class RecetaServices : IRecetaService
{
    private readonly IRecetaRepository _repo;
    private readonly IMapper _mapper;

    public RecetaServices(IRecetaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public IEnumerable<RecetaDto> GetAll() =>
        _mapper.Map<IEnumerable<RecetaDto>>(_repo.GetAll());

    public RecetaDto GetById(int id) =>
        _mapper.Map<RecetaDto>(_repo.GetById(id));

    public void Create(RecetaDto dto)
    {
        var receta = _mapper.Map<Receta>(dto);
        _repo.Add(receta);
    }

    public void Update(RecetaDto dto)
    {
        var receta = _mapper.Map<Receta>(dto);
        _repo.Update(receta);
    }

    public void Delete(int id) => _repo.Delete(id);

    IEnumerable<Receta> IRecetaService.GetAll()
    {
        throw new System.NotImplementedException();
    }

    Receta IRecetaService.GetById(int id)
    {
        throw new System.NotImplementedException();
    }

    public Receta GetByCodigoUnico(string codigo)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<Receta> GetByPacienteId(int pacienteId)
    {
        throw new System.NotImplementedException();
    }

    public void Add(Receta receta)
    {
        throw new System.NotImplementedException();
    }

    public void Update(Receta receta)
    {
        throw new System.NotImplementedException();
    }
}

