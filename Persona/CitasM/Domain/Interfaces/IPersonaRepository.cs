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
         List<Persona> GetAll();
        Task<Persona> GetByDocumentoAsync(int Identificacion);
        Task<List<Persona>> GetList();
        Task AddPersona(Persona addCitas);
        Task<bool> UpdatePerson(Persona addCitas);

    }
}
