using Application.Messaging.Messages;
using MassTransit;

namespace Application.Messaging.Consumers
{
    internal class AddEventConsumer : IConsumer<AddEventMessage>
    {
        public Task Consume(ConsumeContext<AddEventMessage> context)
        {
            throw new NotImplementedException();
        }
    }
}
