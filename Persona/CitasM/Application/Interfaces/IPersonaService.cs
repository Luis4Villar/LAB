using Personas.Application.DTO;
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
        List<PersonaDto> GetAll();

        void AddPersona(PersonaDto persona);

    }
}
