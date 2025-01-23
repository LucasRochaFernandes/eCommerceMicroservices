namespace eCommerce.SharedLibrary.Exceptions;
public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message) : base(message)
    {

    }
}
