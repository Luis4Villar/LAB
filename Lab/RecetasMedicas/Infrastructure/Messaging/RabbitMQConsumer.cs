using RabbitMQ.Client;
using RecetasMedicas.Application.Services;
using System;
using Newtonsoft.Json;
using System.Text;
using RecetasMedicas.Domain.Entities;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;

namespace RecetasMedicas.Infrastructure.Messaging
{
    public class RabbitMQConsumer: IRabbitMQConsumer
    {
        private const string Resetaset = "recetaQueueset";
        private const string HostName = "localhost";
        // private readonly FormulaMedicaServices formulaMedicaService;
        private readonly IFormulaMedicaServices formulaMedicaService;

        public RabbitMQConsumer(IFormulaMedicaServices formulaMedicaService)
        {
            this.formulaMedicaService = formulaMedicaService;
        }

        public async Task<bool> StartListening()
        {
            var factory = new ConnectionFactory() { HostName = HostName };

            if ((factory == null))
                return false;
            

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: Resetaset, durable: false, exclusive: false, autoDelete: false, arguments: null);

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += async (model, ea) =>
                        {

                            var body = ea.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);
                            var receta = JsonConvert.DeserializeObject<FormulaMedica>(message);

                            // Guardar en la base de datos
                            await formulaMedicaService.AddFormulaMedicaAsync(receta);
                        };

                        channel.BasicConsume(queue: Resetaset, autoAck: true, consumer: consumer);
                    }

                return true;
                






            }
        }
    }
}