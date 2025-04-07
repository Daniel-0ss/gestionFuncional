using System.Collections.Generic;
using System.Linq;
using RecetasService.Domain.Entities;

public class RecetaRepository : IRecetaRepository
{
    private readonly AppDbContext _context;

    public RecetaRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Receta> GetAll() => _context.Recetas.ToList();

    public Receta GetById(int id) => _context.Recetas.Find(id);

    public void Add(Receta receta)
    {
        _context.Recetas.Add(receta);
        _context.SaveChanges();
    }

    public void Update(Receta receta)
    {
        var entity = _context.Recetas.Find(receta.Id);
        if (entity == null) return;

        // entity.Descripcion = receta.Descripcion; // This line is causing the error
        entity.CodigoUnico = receta.CodigoUnico; // Assuming you meant to update CodigoUnico instead
        entity.FechaCreacion = receta.FechaCreacion;
        entity.PacienteId = receta.PacienteId;
        entity.Estado = receta.Estado;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var receta = _context.Recetas.Find(id);
        if (receta == null) return;

        _context.Recetas.Remove(receta);
        _context.SaveChanges();
    }

    public Receta GetByCodigoUnico(string codigo)
    {
        return _context.Recetas
                       .FirstOrDefault(r => r.CodigoUnico == codigo);
    }

    public IEnumerable<Receta> GetByPacienteId(int pacienteId)
    {
        return _context.Recetas
                       .Where(r => r.PacienteId == pacienteId)
                       .ToList();
    }
}

