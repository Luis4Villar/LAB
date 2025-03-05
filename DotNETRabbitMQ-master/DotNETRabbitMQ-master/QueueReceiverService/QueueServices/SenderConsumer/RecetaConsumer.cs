using CommonResources;
using MassTransit;

namespace QueueReceiverService.QueueServices.SenderConsumer
{
    public class RecetaConsumer : IConsumer<Receta>
    {
        public async Task Consume(ConsumeContext<Receta> context)
        {
            var product = context.Message;
        }
    }
}
