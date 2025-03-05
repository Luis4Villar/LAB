using Citas.Domain.Entities;
using Citas.Domain.Interfaces;
using Citas.Infraestructura.Controller;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Citas.Infraestructura.Repository
{
	public class CitasRepository : ICitasRepository
    {
		private readonly CitasContext citasContext;

		public CitasRepository(CitasContext citasContext)
		{
			this.citasContext = citasContext;
		}
		public List<CitasM> GetAll()
		{
			return citasContext.Citas.ToList();
		}
        public async Task Add(CitasM addCitas)
		{
            citasContext.Citas.Add(addCitas);
			await citasContext.SaveChangesAsync();
		}
        public async Task<CitasM> GetCitasId(int id)
        {
            return await citasContext.Citas.FirstOrDefaultAsync(c => c.Identificacion == id);
        }
        public async Task UpdateCitas(CitasM citasM)
		{
			var citasExitente = await GetCitasId(citasM.Identificacion);
			if (citasExitente != null)
			{

				citasExitente.Identificacion = citasM.Identificacion;
				citasExitente.Nombres = citasM.Nombres;
				citasExitente.Apellidos = citasM.Apellidos;
				citasExitente.HoraCita = citasM.HoraCita;
                citasExitente.FechaCita = citasM.FechaCita;
                citasExitente.Estado = citasM.Estado;
                await citasContext.SaveChangesAsync();
               
            }
		}

     
        public async Task DeleteCitas(int id)
        {
            var cita = await GetCitasId(id);

            if (cita == null)
            {
                throw new KeyNotFoundException($"No se encontró una cita con el ID {id}.");
            }

            try
            {
                citasContext.Citas.Remove(cita);
                await citasContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Manejo de errores específico
                throw new InvalidOperationException("Error al eliminar la cita.", ex);
            }
        }
    }
}