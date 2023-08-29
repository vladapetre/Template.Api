using Template.Application.Mediator.Responses.Statuses;

namespace Template.Application.Mediator.Responses;

public interface IApplicationResult
{
    public ApplicationStatus Status { get; init; }
}
