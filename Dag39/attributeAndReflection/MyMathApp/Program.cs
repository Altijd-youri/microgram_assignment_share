using System.Reflection;

namespace MyMathApp;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--");
        Console.WriteLine(Assembly.GetExecutingAssembly().Location);
        Console.WriteLine("--");
        Console.WriteLine(Assembly.GetAssembly(typeof(MyMath)).Location);
    }
}