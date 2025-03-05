using CitasMedicas.Domain.Interfaces;
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
		private readonly CitaMedicaContext context;
		public CitaMedicaRepository(CitaMedicaContext context)
		{
			this.context = context;
		}
		public async Task<List<CitaMedica>> GetAll()
		{
			return await context.citamedica.ToListAsync();
		}
	}
}