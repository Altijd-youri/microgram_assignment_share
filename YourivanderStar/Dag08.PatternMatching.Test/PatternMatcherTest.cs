using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag08.PatternMatching;

[TestClass]
public class PatternMatcherTest
{
    [TestMethod]
    public void isNummer_VoldoetAanEenCijferGevolgdDoorPreciesTweeDecimalen()
    {
        PatternMatcher sut = new PatternMatcher();
        const string input = "1.00";
        
        bool result = sut.isNummer(input);
        
        Assert.AreEqual(true, result);
    }
    
    [DataTestMethod]
    [DataRow(false, "A.00")]
    [DataRow(false, "#.00")]
    public void isNummer_VoldoetAan_StartMetCijfer(bool expect, string data)
    {
        PatternMatcher sut = new PatternMatcher();
        
        bool result = sut.isNummer(data);
        
        Assert.AreEqual(expect, result);
    }
    
    [DataTestMethod]
    [DataRow(true, "-1.50")]
    [DataRow(true, "-1.00")]
    public void isNummer_VoldoetAan_MagMetMinustekenBeginnen(bool expect, string data)
    {
        PatternMatcher sut = new PatternMatcher();
        
        bool result = sut.isNummer(data);
        
        Assert.AreEqual(expect, result);
    }
    
    [DataTestMethod]
    [DataRow(true, "123.00")]
    [DataRow(true, "00.80")]
    public void isNummer_VoldoetAan_HeeftEenOfMeerCijfersVoorHetDecimaal(bool expect, string data)
    {
        PatternMatcher sut = new PatternMatcher();
        
        bool result = sut.isNummer(data);
        
        Assert.AreEqual(expect, result);
    }
}