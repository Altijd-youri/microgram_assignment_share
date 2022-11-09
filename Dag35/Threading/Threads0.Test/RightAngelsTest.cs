using System.Diagnostics;

namespace Threads0.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void IsRightAngle_ReturnTrueOnRightAngel()
    {
        var sut = new RightAngels();

        var result = sut.IsRightAngle(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public void IsRightAngle_ReturnWithin4AndAHalfSeconds()
    {
        var sut = new RightAngels();
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        sut.IsRightAngle(3, 4, 5);
        stopwatch.Stop();
        
        Assert.IsTrue(stopwatch.Elapsed <= TimeSpan.FromSeconds(4.5));
    }
}