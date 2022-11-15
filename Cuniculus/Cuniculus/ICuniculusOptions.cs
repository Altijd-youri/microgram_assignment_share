using RabbitMQ.Client;

namespace Cuniculus;

public interface ICuniculusOptions
{
    string ExchangeName { get; }
    string QueueName { get; }

    public IConnectionFactory CreateFactory();

}
