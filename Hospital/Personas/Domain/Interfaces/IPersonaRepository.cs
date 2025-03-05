using Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain.Interfaces
{
    interface IPersonaRepository
    {
        List<Persona> getAll();
    }
}
