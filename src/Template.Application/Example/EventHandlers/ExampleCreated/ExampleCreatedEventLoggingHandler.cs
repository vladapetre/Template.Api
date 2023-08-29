using MediatR;
using Microsoft.Extensions.Logging;
using Template.Application.Mediator.Messages;
using Template.Application.Mediator.Messages.Events;
using Template.Domain.Models.Example.Events;

namespace Template.Application.Example.EventHandlers.ExampleCreated;
internal class ExampleCreatedEventLoggingHandler : IApplicationEventHandler<ExampleCreatedEvent>
{
    private readonly ILogger<ExampleCreatedEventLoggingHandler> _logger;

    public ExampleCreatedEventLoggingHandler(ILogger<ExampleCreatedEventLoggingHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(IApplicationEvent<ExampleCreatedEvent> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Example created {@example}", @event.Payload);
    }
}
