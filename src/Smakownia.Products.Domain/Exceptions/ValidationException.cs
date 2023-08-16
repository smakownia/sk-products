namespace Smakownia.Products.Domain.Exceptions;

public class ValidationException : BadRequestException
{
    public ValidationException(string message) : base(message) { }
}
