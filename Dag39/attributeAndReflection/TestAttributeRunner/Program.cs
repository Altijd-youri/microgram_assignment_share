using System.Reflection;
using MyMathApp;

Assembly assembly = Assembly.GetAssembly(typeof(MyMath));

Console.WriteLine(assembly.GetName().Name);

foreach (Type type in assembly.GetTypes())
{
    Console.WriteLine("\t"+type.Name);
    foreach (MethodInfo method in type.GetMethods())
    {
        // This works
        // Attribute[] attrs = Attribute.GetCustomAttributes(method);
        // foreach (Attribute attr in attrs)  
        // {
        //     Console.WriteLine(attr.GetType().FullName);
        // } 
        
        // This does now works since I replaced 'type' with 'method'.
        foreach (var attribute in method.GetCustomAttributes())
        {
            Console.WriteLine($"\t\t[{attribute.GetType().FullName}]");
        }
        
        Console.WriteLine("\t\t"+method.Name);
    }
}
    