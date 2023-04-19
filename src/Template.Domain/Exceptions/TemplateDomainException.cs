namespace Template.Domain.Exceptions;

public sealed class TemplateDomainException : Exception
{
    public TemplateDomainException() { }

    public TemplateDomainException(string message) : base(message) { }

    public TemplateDomainException(string message, Exception innerException) : base(message, innerException) { }
}
