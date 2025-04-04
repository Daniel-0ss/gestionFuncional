using System.Collections.Generic;
using PersonasService.Domain.Entities;

namespace PersonasService.Domain.Interfaces
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAll();
        Persona GetById(int id);
        void Add(Persona persona);
        void Update(Persona persona);
        void Delete(int id);
    }
}