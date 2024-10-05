using System.Net;

namespace Template.Core.Exceptions;

public readonly record struct ExceptionCode
{
    public int Code { get; private init; }
    public string Message { get; private init; }

    private ExceptionCode( int code, string message ) => (Code, Message) = (code, message);
    private ExceptionCode( int code, Exception exception ) => (Code, Message) = (code, exception.Message);

    public static ExceptionCode NotFound( string message ) => new((int)HttpStatusCode.NotFound, message ?? nameof(NotFound));
    public static ExceptionCode BadRequest( string message ) => new((int)HttpStatusCode.BadRequest, message ?? nameof(BadRequest));

}
