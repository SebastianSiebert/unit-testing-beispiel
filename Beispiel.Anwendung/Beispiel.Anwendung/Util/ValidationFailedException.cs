namespace Beispiel.Anwendung.Util;

public class ValidationFailedException : Exception
{
    public ValidationFailedException(string message) : base(message)
    {
        
    }
}