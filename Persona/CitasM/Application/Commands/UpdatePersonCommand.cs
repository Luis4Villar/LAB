using MediatR;
using Personas.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.Application.Commands
{
	public class UpdatePersonCommand: IRequest<bool> 
	{
        public int Identificacion { get; set; }
        public PersonaDto _personaDto;
        public UpdatePersonCommand(int identificacion, PersonaDto personaDto)
        {
            Identificacion = identificacion;
            _personaDto = personaDto;
        }
    }
}