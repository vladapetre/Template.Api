using MediatR;
using Template.Application.Mediator.Results;

namespace Template.Application.Mediator.Requests;
public interface IApplicationRequest<out TResponse> : IRequest<TResponse> where TResponse : IApplicationResult
{
}

