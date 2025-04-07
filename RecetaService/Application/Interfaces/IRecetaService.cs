using RecetasService.Domain.Entities;
using System.Collections.Generic;

public interface IRecetaService
{
    IEnumerable<Receta> GetAll();
    Receta GetById(int id);
    Receta GetByCodigoUnico(string codigo);
    IEnumerable<Receta> GetByPacienteId(int pacienteId);
    void Add(Receta receta);
    void Update(Receta receta);
    void Delete(int id);
}
