using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Citas.Domain.Entities
{
	public class CitasM
	{
        [Key]
        public int Id { get; set; }
        public int Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string Estado { get; set; }



    }
}
