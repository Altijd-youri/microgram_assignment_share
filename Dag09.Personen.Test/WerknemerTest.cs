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
    public void Werknemer_SalarisIncreasesBy1PercentForEachVerjaarMoment()
    {
        Werknemer sut = new Werknemer("John Doe", 50, 1000.00M);

        sut.Verjaar();
        
        Assert.AreEqual(1010M, sut.Salaris);
    }
}