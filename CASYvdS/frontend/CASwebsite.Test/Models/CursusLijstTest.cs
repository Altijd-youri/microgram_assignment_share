using CASwebsite.Models;

namespace CASwebsite.Test.Models;

[TestClass]
public class CursusLijstTest
{
    [TestMethod]
    public void CursusLijst_CalculateCorrectWeeknumbers_VorigeAndVolgendeWeek()
    {
        var instantieLijst = new List<CursusInstantie>();
        var weeknummer = new Weeknumber(41, 2022);

        var sut = new CursusLijst(weeknummer, instantieLijst);
        
        Assert.AreEqual(41, sut.Weeknummer.Week);
        Assert.AreEqual(2022, sut.Weeknummer.Jaar);
        Assert.AreEqual(40, sut.VorigeWeek.Week);
        Assert.AreEqual(2022, sut.VorigeWeek.Jaar);
        Assert.AreEqual(42, sut.VolgendeWeek.Week);
        Assert.AreEqual(2022, sut.VolgendeWeek.Jaar);
    }
    
    [TestMethod]
    public void CursusLijst_CalculateCorrectWeeknumbers_VorigeAndVolgendeWeek_YearChange()
    {
        var instantieLijst = new List<CursusInstantie>();
        var weeknummer = new Weeknumber(52, 2022);

        var sut = new CursusLijst(weeknummer, instantieLijst);
        
        Assert.AreEqual(52, sut.Weeknummer.Week);
        Assert.AreEqual(2022, sut.Weeknummer.Jaar);
        Assert.AreEqual(51, sut.VorigeWeek.Week);
        Assert.AreEqual(2022, sut.VorigeWeek.Jaar);
        Assert.AreEqual(1, sut.VolgendeWeek.Week);
        Assert.AreEqual(2023, sut.VolgendeWeek.Jaar);
    }
    
    [TestMethod]
    public void CursusLijst_CorrectInstantie_WithYearSupport()
    {
        var instantieLijst = new List<CursusInstantie>()
        {
            new (
                new Cursus("ASPNET", "Programming in ASP.NET", 1), 
                new DateTime(2021, 10, 10)
            )
        };
        var weeknummer = new Weeknumber(41, 2021);

        var sut = new CursusLijst(weeknummer, instantieLijst);
        
        Assert.AreEqual(1, sut.CursusInstanties.Count());
        Assert.IsTrue(sut.CursusInstanties.Any(ci =>
            ci.StartDatum.Year == 2021 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 10 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 1
        ));
    }
}