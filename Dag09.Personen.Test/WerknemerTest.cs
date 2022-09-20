using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag09.Personen.Test;

[TestClass]
public class WerknemerTest
{
    [TestMethod]
    public void Werknemer_IsPersoonAndHasSalaris()
    {
        string naam = "John Doe";
        int leeftijd = 50;
        decimal salaris = 3000.00M;

        Werknemer sut = new Werknemer(naam, leeftijd, salaris);

        bool inheritsFromPersoon = sut is Persoon;
        Assert.IsTrue(inheritsFromPersoon);
        Assert.AreEqual(3000M, sut.Salaris);
    }
    
    [TestMethod]
    public void WerknemerVerjaar_SalarisIncreasesBy1Percent_BeforeOnLeeftijdChangeEvent()
    {
        Werknemer sut = new Werknemer("John Doe", 50, 1000.00M);
        SalarisChangedInTimeListener listener = new ();
        sut.LeeftijdChanged += listener.Handle;

        sut.Verjaar();
        
        Assert.AreEqual(1010M, listener.SalarisOnEvent);
        Assert.AreEqual(1010M, sut.Salaris);
    }

    [TestMethod]
    public void WerknemerSetLeeftijd_AlsoIncreasedSalaris()
    {
        Werknemer sut = new Werknemer("John Doe", 50, 1000.00M);

        sut.Leeftijd += 3;
        
        Assert.AreEqual(1030.30M, sut.Salaris);
        
    }
}