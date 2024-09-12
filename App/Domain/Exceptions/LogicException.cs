namespace Pets_And_Paws_Api.App.Domain.Exceptions;

public class LogicException(string message, int code = 400) : Exception(message)
{
    public int StatusCode { get; } = code;
}