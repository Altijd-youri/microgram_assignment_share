using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag07.Munten.Test;

[TestClass]
public class ValutaOperatorTest
{
    [TestMethod]
    public void Valuta_plusOperator_WithRightConversion()
    {
        // Arrange
        Valuta a = new Valuta(22.04M, Muntsoort.Gulden);
        Valuta b = new Valuta(10M, Muntsoort.Euro);

        // Act
        Valuta result = a + b;

        // Assert
        Assert.AreEqual(44.08M, result.Bedrag);
        Assert.AreEqual(Muntsoort.Gulden, result.Muntsoort);
    }
    
    [TestMethod]
    public void Valuta_multiplyOperator_WithRightConversion()
    {
        // Arrange
        Valuta a = new Valuta(2M, Muntsoort.Gulden);
        Valuta b = new Valuta(5M, Muntsoort.Dukaat);

        // Act
        Valuta result = a * b;

        // Assert
        Assert.AreEqual(51M, result.Bedrag);
        Assert.AreEqual(Muntsoort.Gulden, result.Muntsoort);
    }
    
    [TestMethod]
    public void Valuta_isEqualOperator_WithRightConversion()
    {
        // Arrange
        Valuta a = new Valuta(5.1M, Muntsoort.Gulden);
        Valuta b = new Valuta(1M, Muntsoort.Dukaat);

        // Act
        bool result = a == b;

        // Assert
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void Valuta_isNotEqualOperator_WithRightConversion()
    {
        // Arrange
        Valuta a = new Valuta(5.1M, Muntsoort.Gulden);
        Valuta b = new Valuta(1M, Muntsoort.Dukaat);

        // Act
        bool result = a != b;

        // Assert
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void Valuta_CastOperator_DecimalToEuro()
    {
        // Arrange
        decimal sut = 5M;

        // Act
        Valuta result = sut;

        // Assert
        Assert.AreEqual(5M, result.Bedrag);
        Assert.AreEqual(Muntsoort.Euro, result.Muntsoort);
    }
    
    [TestMethod]
    public void Valuta_CastOperator_GuldenValutaToEuroDecimal()
    {
        // Arrange
        Valuta sut = new Valuta(10M, Muntsoort.Gulden);

        // Act
        decimal result = sut;

        // Assert
        Assert.AreEqual(4.54M, result);
    }
}