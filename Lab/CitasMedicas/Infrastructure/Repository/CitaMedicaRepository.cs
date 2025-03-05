using CitasMedicas.Domain.Interfaces;
using CitasMedicas.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CitasMedicas.Infrastructure.Repository
{
	public class CitaMedicaRepository: ICitaMedicaRepository
	{
        private readonly RabbitMQProduce rabbitMQProduce;
		private readonly CitaMedicaContext context;
        
		public CitaMedicaRepository(CitaMedicaContext context)
		{
			this.context = context;
		}
		public async Task<List<CitaMedica>> GetAll()
		{
			return await context.citamedica.ToListAsync();
		}

        public async Task<List<CitaMedica>> GetByDate(DateTime fecha)
        {
            return await context.citamedica
                .Where(c => DbFunctions.TruncateTime(c.fechacita) == fecha.Date)
                .ToListAsync();
        }
        public async Task<CitaMedica> GetByPersonaId(int idpaciente)
        {
            return await context.citamedica.FirstOrDefaultAsync(c => c.idpaciente == idpaciente);
        }

        public async Task<bool> Update(CitaMedica cita)
        {
            var citaExistente = await context.citamedica.FindAsync(cita.idcita);
            if (citaExistente == null)
                return false;

            citaExistente.idpaciente = cita.idpaciente ?? citaExistente.idpaciente;
            citaExistente.idmedico = cita.idmedico ?? citaExistente.idmedico;
            citaExistente.lugarcita = cita.lugarcita ?? citaExistente.lugarcita;
            citaExistente.fechacita = cita.fechacita ?? citaExistente.fechacita;
            citaExistente.estadocita = cita.estadocita ?? citaExistente.estadocita;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCitaByPacienteId(int idPaciente, CitaMedica cita)
        {
            var citaExistente = await context.citamedica
                .FirstOrDefaultAsync(c => c.idpaciente == idPaciente);

            if (citaExistente == null)
                return false; // No se encontró la cita para el paciente

            // Actualizar los campos si el valor no es nulo
            citaExistente.idmedico = cita.idmedico ?? citaExistente.idmedico;
            citaExistente.lugarcita = cita.lugarcita ?? citaExistente.lugarcita;
            citaExistente.fechacita = cita.fechacita ?? citaExistente.fechacita;
            citaExistente.estadocita = cita.estadocita ?? citaExistente.estadocita;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<CitaMedica> AddCita(CitaMedica cita)
        {
            
            context.citamedica.Add(cita);
            await context.SaveChangesAsync();
            return cita;
        }
        public async Task<bool> DeleteCita(int idcita)
        {
            var cita = await context.citamedica.FindAsync(idcita);
            if (cita == null)
                return false;

            context.citamedica.Remove(cita);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidarExistenciaPersona(int idpaciente)
        {
            return await context.citamedica.AnyAsync(c => c.idpaciente == idpaciente);
        }

        public async Task<bool> FinalizarCitaAsync(int idPaciente, CitaMedica cita)
        {
            var citaMedica = await context.citamedica
                .FirstOrDefaultAsync(c => c.idpaciente == idPaciente);
          

            citaMedica.estadocita = "Finalizada";

            await context.SaveChangesAsync();



            var receta = new
            {
                CodigoReceta = Guid.NewGuid().ToString(),
                IdPaciente = cita.idpaciente,
                FechaEmision = DateTime.UtcNow,
                Estado = "Pendiente",
                Descripcion = "Receta generada automáticamente"
            };
                    

            rabbitMQProduce.SendMessage(receta);
           
            return true;
        }


    }
}