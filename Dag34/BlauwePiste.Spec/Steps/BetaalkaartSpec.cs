using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlauwePiste.Spec.Steps;

[Binding]
public class BetaalkaartSpec
{
    private Betaalkaart? _betaalkaart;
    private string? _gegevenNaam;
    private decimal? _gewenstSaldo;

    
    [Given(@"naam is ""(.*)""")]
    public void GivenNaamIs(string p0)
    {
        _gegevenNaam = p0;
    }

    [Given(@"gewenst saldo is (.*) euro")]
    public void GivenGewenstSaldoIsEuro(int p0)
    {
        _gewenstSaldo = p0;
    }

    [When(@"betaalkaart is aangemaakt")]
    [Given(@"betaalkaart is aangemaakt")]
    public void WhenEenBetaalkaartIsAangemaakt()
    {
        _gegevenNaam = _gegevenNaam ?? "Christina Marilla";
        _gewenstSaldo = _gewenstSaldo ?? 10M;
        
        _betaalkaart = new Betaalkaart(_gegevenNaam, _gewenstSaldo.Value);
    }

    [Then(@"de betaalkaart heeft de opgeven naam en saldo")]
    public void ThenDeBetaalkaartHeeftDeOpgevenNaamEnSaldo()
    {
        Assert.IsNotNull(_betaalkaart);
        Assert.AreEqual(_gegevenNaam, _betaalkaart.Naam);
        Assert.AreEqual(_gewenstSaldo, _betaalkaart.Saldo);
    }

    [When(@"saldo van (.*) euro bijschrijven")]
    public void WhenSaldoVanEuroBijschrijven(int p0)
    {
        Assert.IsNotNull(_betaalkaart);
        _betaalkaart.Saldo += p0;
    }

    [Then(@"saldo blijft onveranderd")]
    public void ThenSaldoBlijftOnveranderd()
    {
        Assert.IsNotNull(_betaalkaart);
        Assert.AreEqual(_gewenstSaldo, _betaalkaart.Saldo);
    }
}