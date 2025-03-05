using Persona.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Persona.Infrastructure.Repository;

namespace Persona.Application.Services
{
    public class PersonaServices : IPersonaServices
    {
        private readonly IPersonaRepository personaRepository;

        public PersonaServices(IPersonaRepository personaRepository)
        {
            this.personaRepository = personaRepository;
        }

        public async Task<List<ListaPersona>> GetAll()
        {
            return await personaRepository.GetAll();
        }

        public async Task<ListaPersona> GetByDocumento(string numeroDocumento)
        {
            return await personaRepository.GetByDocumento(numeroDocumento);
        }
        public async Task<List<ListaPersona>> GetByTipoUsuario(string tipoUsuario)
        {
            return await personaRepository.GetByTipoUsuario(tipoUsuario);
        }
        public async Task<bool> UpdatePersonaByDocumento(string numeroDocumento, ListaPersona persona)
        {
            return await personaRepository.UpdatePersonaByDocumento(numeroDocumento, persona);
        }
        public async Task<bool> AddPersona(ListaPersona nuevaPersona)
        {
            return await personaRepository.AddPersona(nuevaPersona);
        }
        public async Task<bool> DeletePersonaByDocumento(string numeroDocumento)
        {
            return await personaRepository.DeletePersonaByDocumento(numeroDocumento);
        }



    }
}
