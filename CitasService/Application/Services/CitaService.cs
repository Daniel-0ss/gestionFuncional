using System;
using System.Collections.Generic;
using AutoMapper;
using CitasService.Application.Interfaces;
using CitasService.Domain.Entities;
using CitasService.Models;

namespace CitasService.Application.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _repo;
        private readonly IMapper _mapper;

        public CitaService(ICitaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<CitaDto> GetAll() =>
            _mapper.Map<IEnumerable<CitaDto>>(_repo.GetAll());

        public CitaDto GetById(Guid id) =>
            _mapper.Map<CitaDto>(_repo.GetById(id));

        public void Create(CitaDto dto)
        {
            var cita = _mapper.Map<Cita>(dto);
            _repo.Add(cita);
        }

        public void Update(CitaDto dto)
        {
            var cita = _mapper.Map<Cita>(dto);
            _repo.Update(cita);
        }

        public void Delete(Guid id) => _repo.Delete(id);
    }
}
