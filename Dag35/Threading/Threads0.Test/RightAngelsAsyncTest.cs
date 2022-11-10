using System.Diagnostics;

namespace Threads0.Test;

[TestClass]
public class RightAngelsAsyncTest
{
    [TestMethod]
    public async Task IsRightAngle_VariantA_ReturnTrueOnRightAngel()
    {
        var sut = new RightAngelsAsync();

        var result = await sut.IsRightAngel_variantA(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public async Task IsRightAngle_VariantA_ReturnFalseOnOtherAngle()
    {
        var sut = new RightAngelsAsync();

        var result = await sut.IsRightAngel_variantA(1, 4, 5);
        
        Assert.AreEqual(false, result);
    }
    
    [TestMethod]
    public async Task IsRightAngle_VariantA_ReturnsTrueAfterMultipleExecution_TestOnUnintendSharedResources()
    {
        var sut = new RightAngelsAsync();

        await sut.IsRightAngel_variantA(3, 4, 5);
        await sut.IsRightAngel_variantA(1, 4, 5);
        var result = await sut.IsRightAngel_variantA(3, 4, 5);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public async Task IsRightAngle_VariantA_ReturnWithin4AndAHalfSeconds()
    {
        var sut = new RightAngelsAsync();
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        await sut.IsRightAngel_variantA(3, 4, 5);
        stopwatch.Stop();
        
        Assert.IsTrue(stopwatch.Elapsed <= TimeSpan.FromSeconds(4.5));
    }
}