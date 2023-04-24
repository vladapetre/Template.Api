using Template.Application.Errors;

namespace Template.Application.Responses;

public interface IApplicationResponse
{
    public ApplicationError? Error { get; init; }
}
