namespace Cuniculus;

public class DomainEvent
{
    public DateTime Timestamp { get; init; }
    public Guid CorrelationId { get; set; }
 
    public DomainEvent()
    {
        Timestamp = DateTime.UtcNow;
        CorrelationId = Guid.NewGuid();
    }
}
