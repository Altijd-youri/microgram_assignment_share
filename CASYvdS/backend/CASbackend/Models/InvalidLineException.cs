namespace CASbackend.Models;

public class InvalidLineException : Exception
{
    public int Line { get; }

    public InvalidLineException(int line)
    {
        Line = line;
    }
}