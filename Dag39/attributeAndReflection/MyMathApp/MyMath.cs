using TestAttributeLib;

namespace MyMathApp;

public class MyMath
{
    [Test(25, Output = 5)]
    [Test(-25, ExpectedException="ArgumentOutOfRangeException")]
    public int SquareRootInt(int n)
    {
        // …
        return 0;
    }
 
    [Test(2.0, 3.0, Output=2.5)]
    [Test(12.5, 15.0, Output=13.75)]
    public double Average(double a, double b)
    {
        // …
        return 0;
    }
}

