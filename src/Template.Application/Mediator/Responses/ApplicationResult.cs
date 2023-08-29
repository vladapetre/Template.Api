using Template.Application.Mediator.Responses.Statuses;

namespace Template.Application.Mediator.Responses;

public sealed class ApplicationResult : IApplicationResult
{
    public ApplicationStatus Status { get; init; } = default!;

    public static ApplicationResult Ok(string? message = null) => new() { Status = ApplicationStatus.Ok};

    public static ApplicationResult InternalServerError(string? message = null) => new() { Status = ApplicationStatus.InternalServerError };

    public static ApplicationResult BadRequest(string? message = null) => new() { Status = ApplicationStatus.BadRequest};

    public static ApplicationResult NotFound(string? message = null) => new() { Status = ApplicationStatus.NotFound };

    public static ApplicationResult Unauthorized(string? message = null) => new() { Status = ApplicationStatus.Unauthorized };

    public static ApplicationResult Forbidden(string? message = null) => new() { Status = ApplicationStatus.Forbidden };
}
