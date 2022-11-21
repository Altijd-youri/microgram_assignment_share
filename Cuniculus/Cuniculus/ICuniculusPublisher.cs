namespace Cuniculus;

public interface ICuniculusPublisher
{ 
    void Publish<T>(string topic, T evt) where T : DomainEvent;
}