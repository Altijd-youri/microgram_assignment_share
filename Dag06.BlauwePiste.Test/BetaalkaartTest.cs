using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag06.BlauwePiste.Test;

[TestClass]
public class BetaalkaartTest
{
    private Betaalkaart sut;
    
    [TestInitialize]
    public void TestInitialize()
    {
        const string naam = "John Doe";
        const decimal saldo = 15.00M;
        sut = new (naam, saldo);
    }
    
    [TestMethod]
    public void Betaalkaart_create_heeftNaamEnSaldo()
    {
        // Arrange
        const string naam = "John Doe";
        const decimal saldo = 15.00M;
        
        // Act
        Betaalkaart sut = new (naam, saldo);

        // Assert
        Assert.AreEqual("John Doe", sut.Naam);
        Assert.AreEqual(15.00M, sut.Saldo);
    }

    [TestMethod]
    public void Betaalkaart_Saldo_KanNietToenemen()
    {
        // Arrange

        // Act
        sut.Saldo = 16.00M;
        decimal result = sut.Saldo;

        // Assert
        Assert.AreEqual(15.00M, result);

    }

    [TestMethod]
    public void Betaalkaart_Saldo_KanWordenOpgevraagd()
    {
        // Arrange

        // Act
        decimal result = sut.Saldo;
        
        // Assert
        Assert.AreEqual(15.00M, result);
    }

    [TestMethod]
    public void Betaalkaart_betaaling_saldoWordtAfgeschreven()
    {
        // Arrange
        const decimal betalingsBedrag = 5.00M;

        // Act
        sut.Betaal(betalingsBedrag);

        // Assert
        Assert.AreEqual(10.00M, sut.Saldo);
    }

    [TestMethod]
    public void Betaalkaart_betalingBijSaldoTekort_GooitSaldoOntoerijkendException()
    {
        // Arrange
        const decimal betalingsBedrag = 20.00M;

        // Act
        Action action = () => sut.Betaal(betalingsBedrag);

        // Assert
        var exception = Assert.ThrowsException<SaldoOntoerijkendException>(action);
        Assert.AreEqual($"Uw saldo van 15,00 Euro is ontoereikend om een bedrag van 20,00 mee te betalen", exception.Message);
    }
}