using CommonResources;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace QueueSenderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueSenderController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IRequestClient<Receta> _client;

        public QueueSenderController(IBus bus, IRequestClient<Receta> client)
        {
            _bus = bus;
            _client = client;
        }

        [HttpPost("RecetaQueue")]
        public async Task<IActionResult> SendCommand()
        {
            var receta = new Receta()
            {
                  IdReceta=12,
                  Identificacion =23,
                  CodigoReceta =32,
                  Recetas="Almidon,cojuelo",
                  Estado="Activo",
                  Observacion="Receta para mejora la tos" 
            };

            var url = new Uri("rabbitmq://localhost/RecetaQueue");

            var endpoint = await _bus.GetSendEndpoint(url);
            await endpoint.Send(receta);

            return Ok("Command sent successfully");
        }

    }
}
