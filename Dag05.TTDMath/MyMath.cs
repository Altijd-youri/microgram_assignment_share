namespace Dag05.TTDFact;

public class MyMath
{
    public int Fac(int n) => n switch
    {
        <=0 => throw new ArgumentException($"Cannot calculate Fac({n})"),
        1 => 1,
        _ => n * Fac(n - 1)
    };

    public int Fib(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException($"Cannot calculate Fib({n})");
        }
        if (n <= 2)
        {
            return 1;
        }
        else
        {
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}