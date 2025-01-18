namespace eCommerce.SharedLibrary.Exceptions;
public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}
