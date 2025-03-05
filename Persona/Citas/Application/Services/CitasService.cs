using Citas.Application.Intefaces;
using Citas.Domain.Entities;
using Citas.Domain.Interfaces;
using Citas.Application.Dto;
using Citas.Infraestructura.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Citas.Application.Services
{
	public class CitasService :ICitasService
	{
		private readonly ICitasRepository citasRepository;

		public CitasService(ICitasRepository citasRepository)
		{
			this.citasRepository = citasRepository;
		}
		public List<CitasM> GetAll()
		{
			return citasRepository.GetAll();
		}
		public void AddCitas(CitasM addCitas)
		{
			citasRepository.Add(addCitas);
		}
        public async Task<CitasM> GetCitasId(int id)
        {
            return await citasRepository.GetCitasId(id);
        }
        public async Task UpdateCitas(CitasM citasM)
		{
			await citasRepository.UpdateCitas(citasM);
		}
   
        public async Task DeleteCitas(int id)
        {
            await citasRepository.DeleteCitas(id);
        }
        public async Task<bool> FinalizarCita(int id,RecetasDto receta)
        {
            var cita = await citasRepository.GetCitasId(id);
            if (cita == null || receta == null)
            {
                return false;
            }

            cita.Estado = "Prueba";
            await citasRepository.UpdateCitas(cita);


            // Enviar receta a RabbitMQ
            try
            {
                var publisher = new SendMQ();
                await publisher.PublicarMensaje(receta);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar receta: {ex.Message}");
                return false;
            }
        }

    }
}