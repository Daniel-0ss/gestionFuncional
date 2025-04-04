using System.Collections.Generic;
using System.Linq;
using PersonasService.Domain.Entities;
using PersonasService.Infrastructure.Data;

namespace PersonasService.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> GetAll() => _context.Personas.ToList();

        public Persona GetById(int id) => _context.Personas.Find(id);

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void Update(Persona persona)
        {
            var entity = _context.Personas.Find(persona.Id);
            if (entity == null) return;

            entity.Nombre = persona.Nombre;
            entity.TipoPersona = persona.TipoPersona; 
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var persona = _context.Personas.Find(id);
            if (persona == null) return;

            _context.Personas.Remove(persona);
            _context.SaveChanges();
        }
    }
}
