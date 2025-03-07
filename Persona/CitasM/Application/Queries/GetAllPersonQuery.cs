using MediatR;
using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using Personas.Application.DTO;

namespace Personas.Application.Queries
{
	public class GetAllPersonQuery : IRequest<List<PersonaDto>>
    {
        
    }
}