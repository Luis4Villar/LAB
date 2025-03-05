using Citas.Domain.Entities;
using Citas.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Application.Intefaces
{
   public interface ICitasService
    {
        List<CitasM> GetAll();
        void AddCitas(CitasM addCitas);
        Task<CitasM> GetCitasId(int id);
        Task UpdateCitas(CitasM citasM);
        Task DeleteCitas(int id);
        Task<bool> FinalizarCita(int id, RecetasDto receta);
    }
}
