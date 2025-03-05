using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.Application.Mappings
{
	public class CitasMapping : Profile
    {
        public CitasMapping()
        {
          //  CreateMap<RecetasDto, RecetasM>().ReverseMap().ForMember(dest => dest.idReceta, opt => opt.Ignore());
        }
    }
}