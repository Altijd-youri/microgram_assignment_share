namespace Dag09.Personen.Test;

public class LeeftijdChangedListener
{
    public bool HasBeenCalled;
    public LeeftijdChangedEventArgs? Args;
    public object? Sender;
        
    public void Handle(object? sender, LeeftijdChangedEventArgs? args)
    {
        HasBeenCalled = true;
        Sender = sender;
        Args = args;
    }
}