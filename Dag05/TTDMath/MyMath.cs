namespace Dag05.TTDFact;

public class MyMath
{
    public int Fac(int n) => n switch
    {
        <= 0 => throw new ArgumentException($"Cannot calculate Fac({n})"),
        1 => 1,
        _ => n * Fac(n - 1)
    };

    public int Fib(int n) => n switch
    {
        <= 0 => throw new ArgumentException($"Cannot calculate Fib({n})"),
        <= 2 => 1,
        _ => Fib(n - 1) + Fib(n - 2)
    };

    public double XisX1(double x)
    {
        return x + 1;
    }

    public double find(double stop)
    {
        double current = 0;
        while (current < stop)
        {
            current = current - double.MinValue;
        }

        return current;
    }
}