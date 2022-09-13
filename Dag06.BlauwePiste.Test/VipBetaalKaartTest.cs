using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag06.BlauwePiste.Test;

[TestClass]
public class VipBetaalKaartTest
{
    private VipBetaalKaart sut;
    
    [TestInitialize]
    public void TestInitialize()
    {
        const string naam = "John Doe";
        const decimal saldo = 15.00M;
        sut = new (naam, saldo);
    }

    [TestMethod]
    public void VipBetaalKaart_create_kanVipBetaalKaartMaken()
    {
        // Arrange
        const string naam = "John Doe";
        const decimal saldo = 15.00M;
        
        // Act
        VipBetaalKaart sut = new (naam, saldo);

        // Assert
        Assert.AreEqual("John Doe", sut.Naam);
        Assert.AreEqual(15.00M, sut.Saldo);
    }

    [TestMethod]
    public void VipBetaalKaart_betalingMetAlternatieveKorting_saldoWordtAfgeschreven()
    {
        // Arrange
        const string naam = "John Doe";
        const decimal saldo = 15.00M;
        const decimal korting = 20M;
        VipBetaalKaart sut = new (naam, saldo, korting);

        const decimal betalingsBedrag = 10M;
        
        // Act
        sut.Betaal(betalingsBedrag);

        // Assert
        Assert.AreEqual(7.00M, sut.Saldo);
    }

    [TestMethod]
    public void VipBetaalkaart_betalingMetKorting_saldoWordtAfgeschreven()
    {
        // Arrange
        const decimal betalingsBedrag = 10.00M;

        // Act
        sut.Betaal(betalingsBedrag);

        // Assert
        Assert.AreEqual(6.00M, sut.Saldo);
    }
    
    [TestMethod]
    public void VipBetaalkaart_betalingSaldoMinderDanNul_saldoWordtAfgeschreven()
    {
        // Arrange
        const decimal betalingsBedrag = 20.00M;

        // Act
        sut.Betaal(betalingsBedrag);

        // Assert
        Assert.AreEqual(-3.00M, sut.Saldo);
    }
}