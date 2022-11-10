using System.Diagnostics;

namespace Threads0.Test;

[TestClass]
public class RightAngelsTasksTest
{
    [TestMethod]
    public void IsRightAngle_VariantA_ReturnTrueOnRightAngel()
    {
        var sut = new RightAngelsTasks();

        var result = sut.IsRightAngle_VariantA(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public void IsRightAngle_VariantA_ReturnFalseOnOtherAngle()
    {
        var sut = new RightAngelsTasks();

        var result = sut.IsRightAngle_VariantA(1, 4, 5);
        
        Assert.AreEqual(false, result);
    }
    
    [TestMethod]
    public void IsRightAngle_VariantA_ReturnsTrueAfterMultipleExecution_TestOnUnintendSharedResources()
    {
        var sut = new RightAngelsTasks();

        sut.IsRightAngle_VariantA(3, 4, 5);
        sut.IsRightAngle_VariantA(1, 4, 5);
        var result = sut.IsRightAngle_VariantA(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public void IsRightAngle_VariantA_ReturnWithin4AndAHalfSeconds()
    {
        var sut = new RightAngelsTasks();
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        sut.IsRightAngle_VariantA(3, 4, 5);
        stopwatch.Stop();
        
        Assert.IsTrue(stopwatch.Elapsed <= TimeSpan.FromSeconds(4.5));
    }
    
    
    [TestMethod]
    public void IsRightAngle_VariantB_ReturnTrueOnRightAngel()
    {
        var sut = new RightAngelsTasks();

        var result = sut.IsRightAngle_VariantB(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public void IsRightAngle_VariantB_ReturnFalseOnOtherAngle()
    {
        var sut = new RightAngelsTasks();

        var result = sut.IsRightAngle_VariantB(1, 4, 5);
        
        Assert.AreEqual(false, result);
    }
    
    [TestMethod]
    public void IsRightAngle_VariantB_ReturnWithin4AndAHalfSeconds()
    {
        var sut = new RightAngelsTasks();
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        sut.IsRightAngle_VariantB(3, 4, 5);
        stopwatch.Stop();
        
        Assert.IsTrue(stopwatch.Elapsed <= TimeSpan.FromSeconds(4.5));
    }
}