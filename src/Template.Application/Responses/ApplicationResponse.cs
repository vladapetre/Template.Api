using System.Net;
using Template.Application.Errors;

namespace Template.Application.Responses;

public sealed class ApplicationResponse : IApplicationResponse
{
    public ApplicationError? Error { get; init; }


    public static ApplicationResponse Ok(string? message = null) => new() { Error = default };
    public static ApplicationResponse InternalServerError(string? message = null) => new() { Error = new((int)HttpStatusCode.InternalServerError, message ?? nameof(InternalServerError)) };
    public static ApplicationResponse BadRequest(string? message = null) => new() { Error = new((int)HttpStatusCode.BadRequest, message ?? nameof(BadRequest)) };
    public static ApplicationResponse NotFound(string? message = null) => new() { Error = new((int)HttpStatusCode.NotFound, message ?? nameof(NotFound)) };
    public static ApplicationResponse Unauthorized(string? message = null) => new() { Error = new((int)HttpStatusCode.Unauthorized, message ?? nameof(Unauthorized)) };
    public static ApplicationResponse Forbidden(string? message = null) => new() { Error = new((int)HttpStatusCode.Forbidden, message ?? nameof(Forbidden)) };
}
