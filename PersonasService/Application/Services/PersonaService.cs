using System.Collections.Generic;
using AutoMapper;
using PersonasService.Application.Interfaces;
using PersonasService.Domain.Entities;
using PersonasService.Models;

namespace PersonasService.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repo;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<PersonaDto> GetAll() =>
            _mapper.Map<IEnumerable<PersonaDto>>(_repo.GetAll());

        public PersonaDto GetById(int id) =>
            _mapper.Map<PersonaDto>(_repo.GetById(id));

        public void Create(PersonaDto dto)
        {
            var persona = _mapper.Map<Persona>(dto);
            _repo.Add(persona);
        }

        public void Update(PersonaDto dto)
        {
            var persona = _mapper.Map<Persona>(dto);
            _repo.Update(persona);
        }

        public void Delete(int id) => _repo.Delete(id);
    }
}