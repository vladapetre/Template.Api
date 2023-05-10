using Template.Application.Mediator.Responses.Statuses;

namespace Template.Application.Mediator.Responses;

public interface IApplicationResponse
{
    public ApplicationStatus Status { get; init; }
    public string? Message { get; init; }
}
