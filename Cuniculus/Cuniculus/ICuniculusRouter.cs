namespace Cuniculus;

public interface ICuniculusRouter
{
    IEnumerable<string> Topics { get; }
    void Route(EventMessage eventMessage);
}