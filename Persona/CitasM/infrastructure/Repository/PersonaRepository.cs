using Personas.Application.Interfaces;
using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Personas.infrastructure.Repository;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Personas.Application.Services
{

    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaContext _context;

        public PersonaRepository(PersonaContext context)  // ✅ Correcto
        {
            _context = context;
        }

        public List<Persona> GetAll()
        {
            return _context.Persona.ToList();
        }
        public async Task<List<Persona>> GetList()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task<Persona> GetByDocumentoAsync(int Identificacion)
        {
            return await _context.Persona.FirstOrDefaultAsync(p => p.Identificacion == Identificacion);

        }
        public async Task AddPersona(Persona persona)
        {
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> UpdatePerson(Persona persona)
        {

            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;

        }
    }
    }
    