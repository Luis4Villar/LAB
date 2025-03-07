using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.Application.DTO
{
	public class PersonaDto
	{
        public int IdPaciente { get; set; }
        public string TipoIdentificacion { get; set; }
        public int Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoPersonas { get; set; }

    }
}