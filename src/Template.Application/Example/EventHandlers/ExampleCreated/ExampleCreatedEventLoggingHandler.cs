using MediatR;
using Microsoft.Extensions.Logging;
using Template.Application.Mediator.Messaging;
using Template.Domain.Models.Example.Events;

namespace Template.Application.Example.EventHandlers.ExampleCreated;
internal class ExampleCreatedEventLoggingHandler : INotificationHandler<Notification<ExampleCreatedEvent>>
{
    private readonly ILogger<ExampleCreatedEventLoggingHandler> _logger;

    public ExampleCreatedEventLoggingHandler(ILogger<ExampleCreatedEventLoggingHandler> logger)
    {
        _logger = logger;
    }
    public async Task Handle(Notification<ExampleCreatedEvent> notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Example created {@example}", notification.Payload);
    }
}
