using System;
using MediatR;
using Microsoft.Extensions.Logging;
using Template.Application.Extensions;
using Template.Application.Mediator.Responses;
using Template.Application.Mediator.Responses.Statuses;
using Template.Domain.Exceptions;

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
        catch (DomainException domainException)
        {
            _logger.LogError("Unhandled errors - {RequestType} - Request: {@Request} - Errors: {@Exception}", typeName, request, domainException);

            return new TResponse
            {
                Status = new(ApplicationStatus.BadRequest.Code, domainException.Message)
            };
        }
        catch (Exception generalException)
        {
            _logger.LogError("Unhandled errors - {RequestType} - Request: {@Request} - Errors: {@Exception}", typeName, request, generalException);
            return new TResponse
            {
                Status = new(ApplicationStatus.InternalServerError.Code, generalException.Message)
            };
        }
    }
}
