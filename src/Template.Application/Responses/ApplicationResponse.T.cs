using Template.Application.Errors;

namespace Template.Application.Responses;

public sealed class ApplicationResponse<T> : IApplicationResponse
{
    public T? Result { get; init; }
    public ApplicationError? Error { get; init; }

    public static implicit operator ApplicationResponse<T>(ApplicationResponse response) => new() { Result = default, Error = response.Error };

    public static implicit operator ApplicationResponse<T>(T? result) => new() { Result = result, Error = default };

}

