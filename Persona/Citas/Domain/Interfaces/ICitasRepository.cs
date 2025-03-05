using Citas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Domain.Interfaces
{
   public interface ICitasRepository
    {
        List<CitasM> GetAll();
        Task Add(CitasM addCitas);
        Task<CitasM> GetCitasId(int id);
        Task UpdateCitas(CitasM citasM);

        Task DeleteCitas(int id);
  
    }
}
