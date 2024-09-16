using System.Net;

namespace Template.Core.Types;

public record class Error
{
    public readonly HttpStatusCode Code;
    public readonly string Message;

    private Error( HttpStatusCode code, string message ) => (Code, Message) = (code, message);

    public static Error BadRequest( string message = "" ) => new(HttpStatusCode.BadRequest, message);
    public static Error NotFound( string message = "" ) => new(HttpStatusCode.NotFound, message);

}
