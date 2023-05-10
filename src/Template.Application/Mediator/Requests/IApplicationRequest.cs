using MediatR;
using Template.Application.Mediator.Responses;

namespace Template.Application.Mediator.Requests;
public interface IApplicationRequest<out TResponse> : IRequest<TResponse> where TResponse : IApplicationResponse
{
}
