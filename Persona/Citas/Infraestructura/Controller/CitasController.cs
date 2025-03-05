using Citas.Application.Intefaces;
using Citas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Citas.Application.Dto;
using Citas.Application.Services;
using RabbitMQ.Client;

namespace Citas.Infraestructura.Controller
{
    [RoutePrefix("api/Citas")]
    public class CitasController : ApiController
	{
        private readonly ICitasService citasService;

        public CitasController(ICitasService _citasService)
        {
            this.citasService = _citasService;
        }

        [HttpGet]
        public List<CitasM> GetAll()
        {
            return citasService.GetAll();
        }
        [HttpPost]
       
        public IHttpActionResult CrearCita(CitasM addCitas)
        {
            citasService.AddCitas(addCitas);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdateCita(int id, [FromBody] CitasM citasM)
        {
            if (citasM == null || id != citasM.Identificacion)
            {
                return BadRequest("Datos inválidos.");
            }

            var citaExistente =  citasService.GetCitasId(id);
            if (citaExistente == null)
            {
                return NotFound();
            }

            await citasService.UpdateCitas(citasM);
            return Ok("Cita actualizada correctamente.");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> DeleteCita(int id)
        {
            var citaExistente = citasService.GetCitasId(id);
            if (citaExistente == null)
            {
                return NotFound();
            }
            await citasService.DeleteCitas(id);
                return Ok($"Cita con ID {id} eliminada correctamente.");
            
        }
        [HttpPost]
        [Route("{id}")]
        public async Task<IHttpActionResult> FinalizarCita(int id, [FromBody] RecetasDto receta)
        {
            // Verificar si el modelo es válido
            

            bool resultado = await citasService.FinalizarCita(id, receta);

            if (!resultado)
            {
                return NotFound();
            }

            return Ok("Cita finalizada y receta enviada.");
        }

    }
}