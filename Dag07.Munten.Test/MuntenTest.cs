using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag07.Munten.Test;

[TestClass]
public class MuntenTest
{
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
    }
    
    [TestMethod]
    public void Valuta_Creëer_MuntsoortEnBedragCorrect()
    {
        // Arrange
        const Muntsoort muntsoort = Muntsoort.Euro;
        const decimal bedrag = 10M;

        // Act
        Valuta result = new Valuta(bedrag, muntsoort);

        // Assert
        Assert.AreEqual(Muntsoort.Euro, result.Muntsoort);
        Assert.AreEqual(10M, result.Bedrag);
    }

    [DataTestMethod]
    [DataRow("EUR", Muntsoort.Euro)]
    [DataRow("HD", Muntsoort.Dukaat)]
    [DataRow("fl", Muntsoort.Gulden)]
    [DataRow("fl", Muntsoort.Florijn)]
    public void Muntsoort_afkortingRepresentatieEURO_isCorrect(string expected, Muntsoort muntsoort)
    {
        // Act
        string result = muntsoort.afkortingRepresentatie();

        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [DataTestMethod]
    [DataRow("10,00 EUR", Muntsoort.Euro)]
    [DataRow("10,00 HD", Muntsoort.Dukaat)]
    [DataRow("10,00 fl", Muntsoort.Gulden)]
    [DataRow("10,00 fl", Muntsoort.Florijn)]
    public void Muntsoort_toString_isCorrect(string expected, Muntsoort muntsoort)
    {
        //Arrange
        Valuta sut = new (10M, muntsoort);
        
        // Act
        string result = sut.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }
}