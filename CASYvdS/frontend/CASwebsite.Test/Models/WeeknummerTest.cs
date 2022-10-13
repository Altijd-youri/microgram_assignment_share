using CASwebsite.Models;

namespace CASwebsite.Test.Models;

[TestClass]
public class WeeknummerTest
{
    [TestMethod]
    public void Weeknummer_ThrowsExceptionOnInvalidWeeknumber()
    {
        var sut = () => new Weeknumber(53, 2022);

        Assert.ThrowsException<ArgumentOutOfRangeException>(sut);
    }
    
    [TestMethod]
    public void Weeknummer_CreatedObject()
    {
        var sut = new Weeknumber(50, 2022);

        Assert.AreEqual(50, sut.Week);
        Assert.AreEqual(2022, sut.Jaar);
        Assert.AreEqual(52, sut.WeekInJaar);
    }
    
    [TestMethod]
    public void Weeknummer_WeekInJaar_Supports53Weeks()
    {
        var sut = new Weeknumber(41, 2009);
        
        Assert.AreEqual(53, sut.WeekInJaar);
    }
}