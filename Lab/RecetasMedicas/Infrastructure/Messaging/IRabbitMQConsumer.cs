using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasMedicas.Infrastructure.Messaging
{
    public interface IRabbitMQConsumer
    {
        Task<bool> StartListening();
    }
}
