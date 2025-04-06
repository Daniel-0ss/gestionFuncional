using System;
using System.Collections.Generic;
using System.Linq;
using CitasService.Domain.Entities;
using CitasService.Infrastructure.Data;

namespace CitasService.Infrastructure.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly AppDbContext _context;

        public CitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cita> GetAll() => _context.Citas.ToList();

        public Cita GetById(Guid id) => _context.Citas.Find(id);

        public void Add(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
        }

        public void Update(Cita cita)
        {
            var entity = _context.Citas.Find(cita.Id);
            if (entity == null) return;

            entity.Fecha = cita.Fecha;
            entity.Lugar = cita.Lugar;
            entity.PacienteId = cita.PacienteId;
            entity.MedicoId = cita.MedicoId;
            entity.Estado = cita.Estado;

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var cita = _context.Citas.Find(id);
            if (cita == null) return;

            _context.Citas.Remove(cita);
            _context.SaveChanges();
        }
    }
}
