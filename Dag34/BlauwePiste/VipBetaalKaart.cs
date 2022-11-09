namespace BlauwePiste;

public class VipBetaalKaart : Betaalkaart
{
    private decimal _korting;

    public decimal Korting
    {
        get => _korting;
        set => _korting = value;
    }
    
    public VipBetaalKaart(string naam, decimal saldo, decimal korting = 10M) : base(naam, saldo)
    {
        Korting = korting;
    }

    public override void Betaal(decimal bedrag)
    {
        decimal bedragNaKorting = bedrag / 100 * (100 - Korting);
        Saldo -= bedragNaKorting;
    }
}