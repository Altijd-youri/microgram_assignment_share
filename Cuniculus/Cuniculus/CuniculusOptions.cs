using RabbitMQ.Client;

namespace Cuniculus;

public class CuniculusOptions : ICuniculusOptions
{
    public string ExchangeName { get; private set; }
    public string QueueName { get; private set; }

    public string HostName { get; set; } = "localhost";

    public int Port { get; set; } = 5672;

    public string UserName { get; set; } = "guest";

    public string Password { get; set; } = "guest";
    
    public IConnectionFactory CreateFactory()
    {
        return new ConnectionFactory()
        {
            HostName = HostName,
            Port = Port,
            UserName = UserName,
            Password = Password
        };
    }

    public CuniculusOptions(string exchangeName, string queueName)
    {
        ExchangeName = exchangeName;
        QueueName = queueName;
    }
}