using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messaging.Notifications;
public interface INotificationBus
{
    public Task PublishAsync<TEvent>(Notification<TEvent> notification) where TEvent : IEvent;
}
