using MediatR;
using Template.Application.Responses;

namespace Template.Application.Requests;
public interface IApplicationRequest<out TResponse> : IRequest<TResponse> where TResponse : IApplicationResponse
{
}
