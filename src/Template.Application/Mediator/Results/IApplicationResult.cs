using Template.Application.Mediator.Results.Statuses;

namespace Template.Application.Mediator.Results;

public interface IApplicationResult
{
    public ApplicationStatus Status { get; init; }
}
