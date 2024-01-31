namespace Shared.Exceptions;

internal class ConfamException : Exception
{
    public ConfamException()
    { }

    public ConfamException(string message)
        : base(message)
    { }

    public ConfamException(string message, Exception innerException)
        : base(message, innerException)
    { }
}