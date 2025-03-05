using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitasMedicas.Domain.Interfaces
{
   public interface IRabbitMQProduce
    {
     Task<bool> SendMessage(object message);
    }
}