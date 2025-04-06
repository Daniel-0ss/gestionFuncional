using System;
using System.Collections.Generic;
using CitasService.Models;

namespace CitasService.Application.Interfaces
{
    public interface ICitaService
    {
        IEnumerable<CitaDto> GetAll();
        CitaDto GetById(Guid id);
        void Create(CitaDto dto);
        void Update(CitaDto dto);
        void Delete(Guid id);
    }
}
