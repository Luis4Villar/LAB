using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using MediatR;
using Personas.Application.DTO;
using AutoMapper;

namespace Personas.Application.Queries
{
	public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, List<PersonaDto>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        public GetAllPersonQueryHandler(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }
        public async Task<List<PersonaDto>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        { 
            var personas = await _personaRepository.GetList(); 
            return _mapper.Map<List<PersonaDto>>(personas); 
        }
    }
}