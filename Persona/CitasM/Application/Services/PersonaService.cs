using AutoMapper;
using Personas.Application.DTO;
using Personas.Application.Interfaces;
using Personas.Application.Services;
using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Personas.infrastructure.Repository
{
	public class PersonaService:IPersonaService
    {
       

        private IPersonaRepository personaRepository;
        private readonly IMapper _mapper;

        public PersonaService( IPersonaRepository personaRepository, IMapper mapper)
		{
            this.personaRepository = personaRepository;
            this._mapper = mapper;

        }
		public List<PersonaDto> GetAll()
		{
            return _mapper.Map<List<PersonaDto>>(personaRepository.GetAll());
        }
        public void AddPersona(PersonaDto addPersona)
        {
            personaRepository.AddPersona(_mapper.Map<Persona>(addPersona));           
        }
    }
}