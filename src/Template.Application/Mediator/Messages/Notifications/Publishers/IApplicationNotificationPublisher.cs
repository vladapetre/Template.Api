using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Mediator.Messages.Notifications;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messages.Notifications.Publishers;
public interface IApplicationNotificationPublisher
{
    public Task PublishAsync<TEvent>(ApplicationNotification<TEvent> notification) where TEvent : IEvent;
}
