using Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Application.Interfaces
{
    public interface IPersonaService
    {
        List<Persona> GetAll();
      
        void AddPersona(Persona persona);
        Task<Persona> GetPersonaId(int id);
        Task UpdatePersona(Persona persona);
        Task DeletePersona(int id);
    }
}
