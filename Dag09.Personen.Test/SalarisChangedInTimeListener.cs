using System.Buffers.Text;

namespace Dag09.Personen.Test;

public class SalarisChangedInTimeListener : LeeftijdChangedListener
{
    public decimal? SalarisOnEvent;
    public void Handle(object? sender, LeeftijdChangedEventArgs? args)
    {
        base.Handle(sender, args);
        HasBeenCalled = true;

        Werknemer? werknemer = (Werknemer) sender!;
        SalarisOnEvent = werknemer?.Salaris;
    }
}