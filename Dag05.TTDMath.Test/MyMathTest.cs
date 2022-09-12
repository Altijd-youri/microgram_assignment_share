using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag05.TTDFact.Test;

[TestClass]
public class MyMathTest
{
    [TestMethod]
    public void Fac_1_returns1()
    {
        // Arrange
        MyMath subjectUnderTest = new ();
        int n = 1;

        // Act
        int result = subjectUnderTest.Fac(n);

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Fac_2_returns2()
    {
        // Arrange
        MyMath subjectUnderTest = new();
        int n = 2;

        // Act
        int result = subjectUnderTest.Fac(n);

        // Assert
        Assert.AreEqual(2, result);
    }
    
    [TestMethod]
    public void Fac_3_returns6()
    {
        // Arrange
        MyMath subjectUnderTest = new();
        int n = 3;

        // Act
        int result = subjectUnderTest.Fac(n);

        // Assert
        Assert.AreEqual(6, result);
    }
    
    [TestMethod]
    public void Fac_0_ThrowArgumentException()
    {
        // Arrange
        MyMath subjectUnderTest = new();
        int n = 0;

        // Act
        Action act = () =>
        {
            int result = subjectUnderTest.Fac(n);
        };

        // Assert
        var exception = Assert.ThrowsException<ArgumentException>(act);
        Assert.AreEqual("Cannot calculate Fac(0)", exception.Message);
    }
    
    [TestMethod]
    public void Fac_LessThan0_ThrowArgumentException()
    {
        // Arrange
        MyMath subjectUnderTest = new();
        int n = -1;

        // Act
        Action act = () =>
        {
            int result = subjectUnderTest.Fac(n);
        };

        // Assert
        var exception = Assert.ThrowsException<ArgumentException>(act);
        Assert.AreEqual("Cannot calculate Fac(-1)", exception.Message);
    }
}