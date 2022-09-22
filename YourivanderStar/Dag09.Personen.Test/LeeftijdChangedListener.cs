namespace Dag09.Personen.Test;

public class LeeftijdChangedListener
{
    public bool HasBeenCalled;
    public LeeftijdChangedEventArgs? Args;
    public Persoon? Sender;
    public string? Naam;
        
    public virtual void Handle(object? sender, LeeftijdChangedEventArgs? args)
    {
        HasBeenCalled = true;
        Sender = (Persoon) sender!;
        Args = args;
        Naam = Sender.Naam;
    }
}