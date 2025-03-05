using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text.Json;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CitasMedicas.Domain.Interfaces;
using System.Threading.Tasks;
using CitasMedicas.Infrastructure.Repository;

namespace CitasMedicas.Infrastructure.Messaging
{
    public class RabbitMQProduce: IRabbitMQProduce
    {
        private readonly IConnectionFactory connectionFactory;
        private const string recetaQueueGet = "recetaQueue";
        private const string HostName = "localhost";

        public RabbitMQProduce(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<bool> SendMessage(object message)
        {
            var factory = new ConnectionFactory() { HostName = HostName };
            if((factory==null))
                return false;

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: recetaQueueGet, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    string jsonMessage = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(jsonMessage);

                    channel.BasicPublish(exchange: "", routingKey: recetaQueueGet, basicProperties: null, body: body);
                    Console.WriteLine($"[x] Mensaje enviado: {jsonMessage}");
                }
            }

            return true;
        }
    }
}