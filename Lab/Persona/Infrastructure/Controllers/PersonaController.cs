using Persona.Application.Services;
using Persona.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Persona.Infrastructure.Controllers
{
    [RoutePrefix("api/persona")]
    public class PersonaController : ApiController
    {
        private readonly IPersonaServices personaService;
        public PersonaController(IPersonaServices personaService)
        {
            this.personaService = personaService;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await personaService.GetAll());
        }

        [HttpGet]
        [Route("{documento}")]
        public async Task<IHttpActionResult> GetByDocumento(string documento)
        {
            var persona = await personaService.GetByDocumento(documento);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        [HttpGet]
        [Route("{tipoUsuario}")]
        public async Task<IHttpActionResult> GetByTipoUsuario(string tipoUsuario)
        {
            var personas = await personaService.GetByTipoUsuario(tipoUsuario);
            if (personas == null )
            {
                return NotFound();
            }
            return Ok(personas);
        }

        [HttpPut]
        [Route("{numeroDocumento}")]
        public async Task<IHttpActionResult> UpdatePersonaByDocumento(string numeroDocumento, [FromBody] ListaPersona persona)
        {
            if (string.IsNullOrEmpty(numeroDocumento) || persona == null)
                return BadRequest("Número de documento o datos de la persona inválidos");

            var updated = await personaService.UpdatePersonaByDocumento(numeroDocumento, persona);

            if (!updated)
                return NotFound();

            return Ok("Persona actualizada correctamente");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddPersona([FromBody] ListaPersona nuevaPersona)
        {
            if (nuevaPersona == null)
                return BadRequest("Datos inválidos");

            bool resultado = await personaService.AddPersona(nuevaPersona);
            if (!resultado)
                return InternalServerError();

            return Ok("Persona agregada correctamente");
        }
        [HttpDelete]
        [Route("{numeroDocumento}")]
        public async Task<IHttpActionResult> DeleteCita(string numeroDocumento)
        {
            var resultado = await personaService.DeletePersonaByDocumento(numeroDocumento);

            if (!resultado)
                return NotFound();

            return Ok("Persona eliminada correctamente.");
        }


    }
}
