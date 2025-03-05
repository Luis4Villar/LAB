using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Citas.Application;
using Citas.Application.Dto;
using MediatR;
namespace Citas.CQRS.Commands
{
	public class CreateCitasCommand : IRequest<int>
	{
        public RecetasDto Receta { get; set; }

        public CreateCitasCommand(RecetasDto receta)
        {
            Receta = receta;
        }
    }
}