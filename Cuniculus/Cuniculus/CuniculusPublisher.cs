namespace Cuniculus;

public class CuniculusPublisher : ICuniculusPublisher
{
    private readonly IBasicSender _sender;

    public CuniculusPublisher(ICuniculusContext context)
        : this(new BasicSender(context)) { }
    internal CuniculusPublisher(IBasicSender sender)
    {
        _sender = sender;
    }
    
    public void Publish<T>(string topic, T evt) where T : DomainEvent
    {
        throw new NotImplementedException();
    }
}