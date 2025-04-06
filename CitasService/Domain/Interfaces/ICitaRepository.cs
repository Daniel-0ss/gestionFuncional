using CitasService.Domain.Entities;
using System;
using System.Collections.Generic;

public interface ICitaRepository
{
    IEnumerable<Cita> GetAll();
    Cita GetById(Guid id);
    void Add(Cita cita);
    void Update(Cita cita);
    void Delete(Guid id);
}

