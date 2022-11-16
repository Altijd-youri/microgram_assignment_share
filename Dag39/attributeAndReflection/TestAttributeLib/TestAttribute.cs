namespace TestAttributeLib;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class TestAttribute : Attribute
{
    private readonly object[] _inputArgs;
    private object _output = "";
    private string _expectedException = "";

    public object[] InputArgs => _inputArgs;

    public object Output
    {
        get => _output;
        set => _output = value;
    }
    public string ExpectedException
    {
        get => _expectedException;
        set => _expectedException = value;
    }
    
    public TestAttribute(params object[] arguments)
    {
        _inputArgs = arguments;
    }
}