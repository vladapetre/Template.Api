using Template.Application.Responses.Statuses;

namespace Template.Application.Responses;

public sealed class ApplicationResponse : IApplicationResponse
{
    public ApplicationStatus Status { get; init; } = default!;

    public string? Message { get; init; }

    public static ApplicationResponse Ok(string? message = null) => new() { Status = ApplicationStatus.Ok, Message = message };

    public static ApplicationResponse InternalServerError(string? message = null) => new() { Status = ApplicationStatus.InternalServerError, Message = message };

    public static ApplicationResponse BadRequest(string? message = null) => new() { Status = ApplicationStatus.BadRequest, Message = message };

    public static ApplicationResponse NotFound(string? message = null) => new() { Status = ApplicationStatus.NotFound, Message = message };

    public static ApplicationResponse Unauthorized(string? message = null) => new() { Status = ApplicationStatus.Unauthorized, Message = message };

    public static ApplicationResponse Forbidden(string? message = null) => new() { Status = ApplicationStatus.Forbidden, Message = message };
}
