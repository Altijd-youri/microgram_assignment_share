using System.Text;

namespace Cuniculus;

public class BasicSender : IBasicSender
{
    private readonly ICuniculusContext _context;

    public BasicSender(ICuniculusContext context)
    {
        _context = context;
    }

    public void Send(EventMessage message)
    {
        var messageBytes = Encoding.Unicode.GetBytes(message.Body);
        var channel = _context.CreateChannel();
        channel.BasicPublish(_context.Options.ExchangeName, message.Topic,false,null,messageBytes);
    }
}