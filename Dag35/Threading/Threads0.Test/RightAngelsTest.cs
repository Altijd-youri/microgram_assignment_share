using System.Diagnostics;

namespace Threads0.Test;

[TestClass]
public class RightAngelsTest
{
    [TestMethod]
    public void IsRightAngle_VariantA_ReturnTrueOnRightAngel()
    {
        var sut = new RightAngels();

        var result = sut.IsRightAngle_VariantA(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public void IsRightAngle_VariantA_ReturnWithin4AndAHalfSeconds()
    {
        var sut = new RightAngels();
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        sut.IsRightAngle_VariantA(3, 4, 5);
        stopwatch.Stop();
        
        Assert.IsTrue(stopwatch.Elapsed <= TimeSpan.FromSeconds(4.5));
    }
    
    
    [TestMethod]
    public void IsRightAngle_VariantB_ReturnTrueOnRightAngel()
    {
        var sut = new RightAngels();

        var result = sut.IsRightAngle_VariantB(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public void IsRightAngle_VariantB_ReturnWithin4AndAHalfSeconds()
    {
        var sut = new RightAngels();
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        sut.IsRightAngle_VariantB(3, 4, 5);
        stopwatch.Stop();
        
        Assert.IsTrue(stopwatch.Elapsed <= TimeSpan.FromSeconds(4.5));
    }
    
    
    [TestMethod]
    public void IsRightAngle_VariantC_ReturnTrueOnRightAngel()
    {
        var sut = new RightAngels();

        var result = sut.IsRightAngle_VariantC(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public void IsRightAngle_VariantC_ReturnWithin4AndAHalfSeconds()
    {
        var sut = new RightAngels();
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        sut.IsRightAngle_VariantC(3, 4, 5);
        stopwatch.Stop();
        
        Assert.IsTrue(stopwatch.Elapsed <= TimeSpan.FromSeconds(4.5));
    }
}