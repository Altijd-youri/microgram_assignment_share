namespace Dag09.Personen.Test;

public class SalarisChangedInTimeListener : LeeftijdChangedListener
{
    public decimal? SalarisOnEvent;
    public override void Handle(object? sender, LeeftijdChangedEventArgs? args)
    {
        base.Handle(sender, args);

        Werknemer? werknemer = (Werknemer) sender!;
        SalarisOnEvent = werknemer?.Salaris;
    }
}