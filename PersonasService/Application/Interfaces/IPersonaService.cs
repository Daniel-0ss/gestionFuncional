using System.Collections.Generic;
using PersonasService.Models;

namespace PersonasService.Application.Interfaces
{
    public interface IPersonaService
    {
        IEnumerable<PersonaDto> GetAll();
        PersonaDto GetById(int id);
        void Create(PersonaDto dto);
        void Update(PersonaDto dto);
        void Delete(int id);
    }
}

