using MediatR;
using Template.Application.Mediator.Messages.Events;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messages;
internal interface IApplicationEventHandler<TEvent> : INotificationHandler<IApplicationEvent<TEvent>> where TEvent : IEvent
{
}
