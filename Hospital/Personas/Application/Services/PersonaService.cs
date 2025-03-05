using Personas.Application.Interfaces;
using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using Personas.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            this.personaRepository = personaRepository; 
        }
        public List<Persona> GetAll()
        {
            return personaRepository.getAll();
        }
    }
	
    
}