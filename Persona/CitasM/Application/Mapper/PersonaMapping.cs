using AutoMapper;
using Personas.Application.DTO;
using Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.Application.Mapper
{
	public class PersonaMapping : Profile
    {
        public PersonaMapping()
        {
             CreateMap<Persona, PersonaDto>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); // Ignora nulos
            ;
        }
    }
}