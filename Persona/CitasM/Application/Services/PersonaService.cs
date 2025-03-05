using Personas.Application.Interfaces;
using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return  personaRepository.getAll();
        }
        public void AddPersona(Persona persona)
        {
            personaRepository.Add(persona);
        }
        public async Task<Persona> GetPesonaId(int id)
        {
            return await personaRepository.GetPersonaId(id);
        }
        public async Task<Persona> GetPersonaId(int id)
        {
            return await personaRepository.GetPersonaId(id);
        }
        public async Task UpdatePersona(Persona persona)
        {
            await personaRepository.UpdatePersona(persona);
        }

        public async Task DeletePersona(int id)
        {
            await personaRepository.DeletePersona(id);
        }
    }

}