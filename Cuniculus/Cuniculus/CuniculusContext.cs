using RabbitMQ.Client;

namespace Cuniculus;

public class CuniculusContext : ICuniculusContext
{
    private static readonly object ConnectionLock = new ();
    private IConnection? _connection;

    public IConnection Connection
    {
        get
        {
            if (_connection != null) return _connection;
            lock (ConnectionLock)
            {
                return FirstConnection();
            }
        }
    }

    private IConnection FirstConnection()
    {
        if (_connection == null)
        {
            _connection = Options.CreateFactory().CreateConnection();
            CreateTopicExchange(_connection);
        }
        return _connection!;
    }

    private void CreateTopicExchange(IConnection connection)
    {
        IModel channel = connection.CreateModel();
        channel.ExchangeDeclare(Options.ExchangeName, ExchangeType.Direct, true);
    }
    
    public ICuniculusOptions Options { get; }
    
    public CuniculusContext(ICuniculusOptions options)
    {
        Options = options;
    }

    public void Dispose()
    {
        _connection?.Dispose();
        GC.SuppressFinalize(this);
    }

    public IModel CreateChannel()
    {
        return Connection.CreateModel();
    }
}