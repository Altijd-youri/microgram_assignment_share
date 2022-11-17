using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Cuniculus;

public class BasicReceiver : IBasicReceiver
{
    private readonly ICuniculusContext _context;
    private bool _setupCalled;
    private bool _setupFinished;
    private bool _startedReceivingFinished;
    private bool _startReceivingCalled;
 
    public BasicReceiver(ICuniculusContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    private void CheckSetupQueue(IEnumerable<string> topics)
    {
        if (!topics.Any()) throw new CuniculusException("No topic(s) provided.");
        if (_setupCalled || _setupFinished) throw new CuniculusException("SetupQueue already done.");
        _setupCalled = true;
    }

    public void SetupQueue(IEnumerable<string> topics)
    {
        var topicList = (List<string>)topics;
        CheckSetupQueue(topicList);

        try
        {
            var channel = _context.CreateChannel();
            channel.QueueDeclare(_context.Options.QueueName, true, false, false, new Dictionary<string, object>());
            foreach (var topic in topicList)
            {
                channel.QueueBind(_context.Options.QueueName, _context.Options.ExchangeName, topic,
                    new Dictionary<string, object>());
            }
            _setupFinished = true;
        }
        catch (Exception e)
        {
            _setupCalled = false;
        }
    }
    
    private void CheckStartReceiving()
    {
        if (_startReceivingCalled || _startedReceivingFinished) throw new CuniculusException("StartReceiving already done.");
        if (!_setupFinished) throw new CuniculusException("SetupQueue not finished.");
        _startReceivingCalled = true;
    }

    public void StartReceiving(Action<EventMessage> handler)
    {
        CheckStartReceiving();
        try
        {
            var channel = _context.CreateChannel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.Unicode.GetString(ea.Body.ToArray());
                var eventMessage = new EventMessage(ea.RoutingKey, message);
                var deliveryTag = ea.DeliveryTag;
                try
                {
                    handler.Invoke(eventMessage);
                    channel.BasicAck(deliveryTag, false);
                }
                catch (Exception e)
                {
                    channel.BasicNack(deliveryTag, false, true);
                }
                
            };
            channel.BasicConsume(queue: _context.Options.QueueName,
                autoAck: false,
                consumer: consumer);
            _startedReceivingFinished = true;
        }
        catch (Exception e)
        {
            _startReceivingCalled = false;
        }
    }
}
