using Template.Application.Responses.Statuses;

namespace Template.Application.Responses;

public interface IApplicationResponse
{
    public ApplicationStatus Status { get; init; }
    public string? Message { get; init; }
}
