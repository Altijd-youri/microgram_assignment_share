using MathLib;

namespace Threads0;

public class RightAngels
{
    public bool IsRightAngle(int a, int b, int c)
    {
        SlowMath math = new SlowMath();

        var aSquareAsyncResult = math.BeginSquare(a, SquareResult, math);
        var bSquareAsyncResult = math.BeginSquare(b, SquareResult, math);
        var cSquareAsyncResult = math.BeginSquare(c, SquareResult, math);

        var aSquare = math.EndSquare(aSquareAsyncResult);
        var bSquare = math.EndSquare(bSquareAsyncResult);
        var cSquare = math.EndSquare(cSquareAsyncResult);
        
        return aSquare + bSquare == cSquare;
    }

    private void SquareResult(IAsyncResult ar)
    {
        Console.WriteLine("this ran");
        SlowMath? math = ar.AsyncState as SlowMath;
        
        Console.WriteLine(math.EndSquare(ar)); 
    }
}