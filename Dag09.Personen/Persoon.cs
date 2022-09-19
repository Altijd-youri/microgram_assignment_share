﻿namespace Dag09.Personen;

public class Persoon
{
    public event LeeftijdChangedEventHandler? LeeftijdChanged;

    private int _leeftijd;
    public int Leeftijd
    {
        get => _leeftijd;
        set
        {
            int oudeLeeftijd = _leeftijd;
            _leeftijd = value;
            OnLeeftijdChanged(new LeeftijdChangedEventArgs(Leeftijd, oudeLeeftijd, Naam));
        }
    }
    public string Naam { get; }

    public Persoon (string naam, int leeftijd)
    {
        Naam = naam;
        Leeftijd = leeftijd;
    }

    public void Verjaar()
    {
        Leeftijd++;
    }
    protected virtual void OnLeeftijdChanged(LeeftijdChangedEventArgs e)
    {
        LeeftijdChangedEventHandler? temp = LeeftijdChanged;
        temp?.Invoke(this, e);
    }
    
}