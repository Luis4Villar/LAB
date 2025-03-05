using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.Infraestructure.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaContext context;

        public PersonaRepository(PersonaContext context)
        {
            this.context = context;

        }
        public List<Persona> getAll()
        {
            return context.Persona.ToList();
        }
    }
}