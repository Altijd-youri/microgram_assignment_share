using MathLib;

namespace Threads0;

public class RightAngelsTasks
{
    public bool IsRightAngle_VariantA(int a, int b, int c)
    {
        var math = new SlowMath();

        Task<int> calcA = new Task<int>(() => math.Square(a));
        Task<int> calcB = new Task<int>(() => math.Square(b));
        Task<int> calcC = new Task<int>(() => math.Square(c));
        
        calcA.Start();
        calcB.Start();
        calcC.Start();

        var abResult = calcA.Result + calcB.Result;
        return abResult == calcC.Result;
    }

    public bool IsRightAngle_VariantB(int a, int b, int c)
    {
        var math = new SlowMath();

        int resultA = 0;
        int resultB = 0;
        int resultC = 0;

        Parallel.Invoke(
            () => resultA = math.Square(a), 
            () => resultB = math.Square(b), 
            () => resultC = math.Square(c)
        );

        return resultA + resultB == resultC;
    }
}