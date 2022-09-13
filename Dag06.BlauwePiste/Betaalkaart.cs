namespace Dag06.BlauwePiste;

public class Betaalkaart
{
    public string Naam;

    private decimal _saldo;
    public decimal Saldo
    {
        get => _saldo;
        set
        {
            if (value < _saldo) _saldo = value;   
        }
    }

    public Betaalkaart(string naam, decimal saldo)
    {
        Naam = naam;
        _saldo = saldo;
    }

    public void Betaal(decimal bedrag)
    {
        if (bedrag > Saldo) throw new SaldoOntoerijkendException(Saldo, bedrag);
        Saldo -= bedrag;
    }
}