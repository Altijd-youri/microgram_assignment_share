using MathLib;

namespace Threads0;

public class RightAngels
{
    public bool IsRightAngle_VariantA(int a, int b, int c)
    {
        SlowMath math = new SlowMath();

        var aSquareAsyncResult = math.BeginSquare(a, null, null);
        var bSquareAsyncResult = math.BeginSquare(b,null, null);
        var cSquareAsyncResult = math.BeginSquare(c, null, null);

        var aSquare = math.EndSquare(aSquareAsyncResult);
        var bSquare = math.EndSquare(bSquareAsyncResult);
        var cSquare = math.EndSquare(cSquareAsyncResult);
        
        return aSquare + bSquare == cSquare;
    }

    public bool IsRightAngle_VariantB(int a, int b, int c)
    {
        int aSquare = 0;
        int bSquare = 0;
        int cSquare = 0;
        
        Thread threadA = new Thread(() => SquareHelper_VariantB(a, out aSquare));
        Thread threadB = new Thread(() => SquareHelper_VariantB(b, out bSquare));
        Thread threadC = new Thread(() => SquareHelper_VariantB(c, out cSquare));
        threadA.Start();
        threadB.Start();
        threadC.Start();
        
        threadA.Join();
        threadB.Join();
        threadC.Join();
        
        return aSquare + bSquare == cSquare;
    }

    private void SquareHelper_VariantB(int number, out int result)
    {
        SlowMath math = new SlowMath();
        result = math.Square(number);
    }


    public bool IsRightAngle_VariantC(int a, int b, int c)
    {
        throw new NotImplementedException();
    }
}