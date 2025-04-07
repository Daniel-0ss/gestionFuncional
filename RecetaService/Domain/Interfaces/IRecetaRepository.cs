using RecetasService.Domain.Entities;
using System.Collections.Generic;

public interface IRecetaRepository
{
    IEnumerable<Receta> GetAll();
    Receta GetById(int id);
    void Add(Receta receta);
    void Update(Receta receta);
    void Delete(int id);
    Receta GetByCodigoUnico(string codigo);
    IEnumerable<Receta> GetByPacienteId(int pacienteId);
}

