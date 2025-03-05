using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.Application.Dto
{
	public class RecetasDto
	{
		public int idReceta { get; set; }
        public int Identificacion{ get; set; }
        public int CodigoReceta{ get; set; }
        public string Receta{ get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
	}
}