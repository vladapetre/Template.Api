using MediatR;
using Microsoft.Extensions.Logging;
using Template.Application.Extensions;
using Template.Application.Mediator.Responses;

namespace Template.Application.Mediator.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    where TResponse : IApplicationResponse, new()
{
    private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;

    public ExceptionHandlingBehavior(ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var typeName = request.GetGenericTypeName();

        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            _logger.LogError("Unhandled errors - {RequestType} - Request: {@Request} - Errors: {@Exception}", typeName, request, exception);

            return new TResponse
            {
                Status = new(500, exception.Message)
            };
        }
    }
}
