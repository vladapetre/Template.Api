using System.Net;

namespace Template.Core.Types;

public readonly record struct Error
{
    public int Code { get; private init; }
    public string Message { get; private init; }

    private Error( int code, string message ) => (this.Code, this.Message) = (code, message);
    private Error( int code, Exception exception ) => (this.Code, this.Message) = (code, exception.Message);

    public static Error NotFound( string message ) => new((int)HttpStatusCode.NotFound, message ?? nameof(NotFound));
    public static Error BadRequest( string message ) => new((int)HttpStatusCode.BadRequest, message ?? nameof(BadRequest));

}
