using RabbitMQ.Client;

namespace Cuniculus;

public interface ICuniculusContext : IDisposable
{
    IConnection Connection { get; }
    
    ICuniculusOptions Options { get; }
    IModel CreateChannel();
}