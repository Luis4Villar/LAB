using Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain.Interfaces
{
    public interface IPersonaRepository
    {
         List<Persona> getAll();
        void Add(Persona addCitas);
        Task<Persona> GetPersonaId(int id);
        Task UpdatePersona(Persona persona);
        Task DeletePersona(int id);
    }
}
