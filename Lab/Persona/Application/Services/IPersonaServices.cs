
using Persona.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Application.Services
{
   public  interface IPersonaServices
    {
        Task<List<ListaPersona>> GetAll();
        Task<ListaPersona> GetByDocumento(string numeroDocumento);
        Task<List<ListaPersona>> GetByTipoUsuario(string tipoUsuario);
        Task<bool> UpdatePersonaByDocumento(string numeroDocumento, ListaPersona persona);
        Task<bool> AddPersona(ListaPersona nuevaPersona);
        Task<bool> DeletePersonaByDocumento(string numeroDocumento);


    }
}
