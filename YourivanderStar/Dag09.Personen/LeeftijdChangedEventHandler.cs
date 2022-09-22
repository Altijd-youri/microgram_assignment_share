namespace Dag09.Personen;

public delegate void LeeftijdChangedEventHandler(object sender, LeeftijdChangedEventArgs args);

public class LeeftijdChangedEventArgs : EventArgs
{
    public readonly int Leeftijd;
    public readonly int OudeLeeftijd;

    public LeeftijdChangedEventArgs(int leeftijd, int oudeLeeftijd)
    {
        Leeftijd = leeftijd;
        OudeLeeftijd = oudeLeeftijd;
    }
}