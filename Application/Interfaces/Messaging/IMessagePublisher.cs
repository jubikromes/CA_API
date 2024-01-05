namespace Application.Interfaces.Messaging;

public interface IMessagePublisher
{
    Task Publish<T>(T message);
    Task SendToQueue<T>(T message, string queue, CancellationToken cancellationToken = default);
}
