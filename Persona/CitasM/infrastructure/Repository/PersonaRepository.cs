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
	public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaContext personacontext;

        public PersonaRepository(PersonaContext personacontext)
		{
			this.personacontext = personacontext;

        }
		public List<Persona> getAll()
		{
			return personacontext.Persona.ToList();
		}
        public void Add(Persona addPersona)
        {
            personacontext.Persona.Add(addPersona);
            personacontext.SaveChanges();
        }
        public async Task<Persona> GetPersonaId(int id)
        {
            return await personacontext.Persona.FirstOrDefaultAsync(c => c.Identificacion == id);
        }
        public async Task UpdatePersona(Persona persona)
        {
            var citasExitente = await GetPersonaId(persona.Identificacion);
            if (citasExitente != null)
            {
                citasExitente.TipoIdentificacion = persona.TipoIdentificacion;
                citasExitente.Identificacion = persona.Identificacion;
                citasExitente.Nombres = persona.Nombres;
                citasExitente.Apellidos = persona.Apellidos;
              
                await personacontext.SaveChangesAsync();
            }
        }


        public async Task DeletePersona(int id)
        {
            var cita = await GetPersonaId(id);
                        
                personacontext.Persona.Remove(cita);
                await personacontext.SaveChangesAsync();
            
        }
    }
}