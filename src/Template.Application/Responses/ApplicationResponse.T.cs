using Template.Application.Responses.Statuses;

namespace Template.Application.Responses;

public sealed class ApplicationResponse<T> : IApplicationResponse
{
    public T? Result { get; init; }
    public ApplicationStatus Status { get; init; } = default!;
    public string? Message { get; init; }

    public static implicit operator ApplicationResponse<T>(ApplicationResponse response) => new() { Result = default, Status = response.Status };

    public static implicit operator ApplicationResponse<T>(T? result) => new() { Result = result, Status = default! };
}
