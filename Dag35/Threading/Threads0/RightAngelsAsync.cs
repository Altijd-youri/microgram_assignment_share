using MathLib;

namespace Threads0;

public class RightAngelsAsync
{
    public async Task<bool> IsRightAngel_variantA(int a, int b, int c)
    {
        var math = new SlowMath();

        Task<int>[] tasks = {
            math.SquareAsync(a),
            math.SquareAsync(b),
            math.SquareAsync(c)
        };
        
       int[] result = await Task.WhenAll(tasks);

        return result[0] + result[1] == result[2];
    }
}