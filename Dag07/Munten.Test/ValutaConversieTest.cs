using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Munten.Test;

[TestClass]
public class ValutaConversieTest
{
    [TestMethod]
    public void Valuta_ConvertGulden10To_Euro()
    {
        Valuta sut = new (10M, Muntsoort.Gulden);
        Valuta result = sut.ConvertTo(Muntsoort.Euro);
        Assert.AreEqual(4.54M, result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertGulden100To_Euro()
    {
        Valuta sut = new (100M, Muntsoort.Gulden);
        Valuta result = sut.ConvertTo(Muntsoort.Euro);
        Assert.AreEqual(45.38M, result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertGulden1000To_Euro()
    {
        Valuta sut = new (1000M, Muntsoort.Gulden);
        Valuta result = sut.ConvertTo(Muntsoort.Euro);
        Assert.AreEqual(453.78M, result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertGulden51To_Dukaat()
    {
        Valuta sut = new (51M, Muntsoort.Gulden);
        Valuta result = sut.ConvertTo(Muntsoort.Dukaat);
        Assert.AreEqual(10M, result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertDukaat10To_Gulden()
    {
        Valuta sut = new (10M, Muntsoort.Dukaat);
        Valuta result = sut.ConvertTo(Muntsoort.Gulden);
        Assert.AreEqual(51M, result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertDukaat100To_Gulden()
    {
        Valuta sut = new (100M, Muntsoort.Dukaat);
        Valuta result = sut.ConvertTo(Muntsoort.Gulden);
        Assert.AreEqual(510M, result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertDukaat1000To_Gulden()
    {
        Valuta sut = new (1000M, Muntsoort.Dukaat);
        Valuta result = sut.ConvertTo(Muntsoort.Gulden);
        Assert.AreEqual(5100M, result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertEuro10To_Gulden()
    {
        Valuta sut = new (10M, Muntsoort.Euro);
        Valuta result = sut.ConvertTo(Muntsoort.Gulden);
        Assert.AreEqual(22.04M , result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertEuro100To_Gulden()
    {
        Valuta sut = new (100M, Muntsoort.Euro);
        Valuta result = sut.ConvertTo(Muntsoort.Gulden);
        Assert.AreEqual(220.37M , result.Bedrag);
    }
    
    [TestMethod]
    public void Valuta_ConvertEuro1000To_Gulden()
    {
        Valuta sut = new (1000M, Muntsoort.Euro);
        Valuta result = sut.ConvertTo(Muntsoort.Gulden);
        Assert.AreEqual(2203.71M , result.Bedrag);
    }
}