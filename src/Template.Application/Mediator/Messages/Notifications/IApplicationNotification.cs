using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messages.Notifications;
internal interface IApplicationNotification<TEvent> where TEvent : IEvent
{
    TEvent Payload { get; init; }
}
