using Personas.Application.Interfaces;
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

        public PersonaController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }
        [HttpGet]
        public List<Persona> getAll()
        {
            return personaService.GetAll();
        }

        [HttpPost]

        public IHttpActionResult CrearPersona(Persona persona)
        {
            personaService.AddPersona(persona);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdatePersona(int id, [FromBody] Persona persona)
        {
            if (persona == null || id != persona.Identificacion)
            {
                return BadRequest("Datos inválidos.");
            }

            var personaExistente = await personaService.GetPersonaId(id);
            if (personaExistente == null)
            {
                return NotFound();
            }

            await personaService.UpdatePersona(persona);
            return Ok("Cita actualizada correctamente.");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> DeletePersona(int id)
        {
            var citaExistente = await personaService.GetPersonaId(id);
            if (citaExistente == null)
            {
                return NotFound();
            }
            await personaService.DeletePersona(id);
            return Ok($"Cita con ID {id} eliminada correctamente.");

        }
    }
}