using MediatR;
using Template.Application.Mediator.Responses;

namespace Template.Application.Mediator.Requests;
public interface IApplicationRequestHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IApplicationRequest<TResponse>
    where TResponse : IApplicationResponse
{
}
