using Template.Application.Mediator.Responses.Statuses;

namespace Template.Application.Mediator.Responses;

public sealed class ApplicationResult<TValue, TError> : IApplicationResult
{
    public TValue? Value { get; init; }
    public ApplicationStatus Status { get; init; } = default!;
    public TError? Error { get; init; }

    public static implicit operator ApplicationResult<TValue, TError>(ApplicationResult response) => new() { Value = default, Status = response.Status };

    public static implicit operator ApplicationResult<TValue, TError>(TValue? result) => new() { Value = result, Status = ApplicationStatus.Ok };
}
