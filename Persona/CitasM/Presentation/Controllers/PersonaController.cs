using AutoMapper;
using MediatR;
using Personas.Application.DTO;
using Personas.Application.Interfaces;
using Personas.Application.Queries;
using Personas.Application.Commands;
using Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Personas.infrastructure.Controllers
{
    [RoutePrefix("api/Persona")]
    public class PersonaController : ApiController
    {
        private readonly IPersonaService personaService;
        private readonly IMapper _mapper;
        private readonly IMediator mediator;

        public PersonaController(IPersonaService personaService, IMapper mapper, IMediator mediator)
        {
            this._mapper = mapper;
            this.personaService = personaService;
            this.mediator = mediator;
        }
       /* [HttpGet]*/
        public List<PersonaDto> GetAll()
        {
            var personas = personaService.GetAll();
            return _mapper.Map<List<PersonaDto>>(personas);
         
        }
        [HttpPost]

        public IHttpActionResult CrearPersona(PersonaDto persona)
        {
            personaService.AddPersona(persona);
            return Ok();
        }
        [HttpGet]
        [Route]
        public async Task<IHttpActionResult> GetAllList()
        {
            var personas = await mediator.Send(new GetAllPersonQuery());
            return Ok(personas);
        }
        [HttpGet]
        [Route("{Identificacion}")]
        public async Task<IHttpActionResult> GetByDocumentPersonQuery(int Identificacion)
        {
            var result = await mediator.Send(new GetByDocumentPersonQuery(Identificacion));
            return Ok(result);
        }
        [HttpPut]
        [Route("{Identificacion}")]
        public async Task<IHttpActionResult> UpdatePerson(int Identificacion,[FromBody] PersonaDto personaDto)
        {
            var command = new UpdatePersonCommand(Identificacion, personaDto);
            var result = await mediator.Send(command);
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}