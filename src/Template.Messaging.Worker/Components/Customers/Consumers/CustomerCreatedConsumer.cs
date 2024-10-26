using MassTransit;
using Template.Domain.Components.Customers.Events;

namespace Template.Messaging.Worker.Components.Customers.Consumers;

internal sealed class CustomerCreatedConsumer : IConsumer<CustomerCreatedEvent>
{
    private readonly ILogger<CustomerCreatedConsumer> logger;

    public CustomerCreatedConsumer( ILogger<CustomerCreatedConsumer> logger )
    {
        this.logger = logger;
    }

    public Task Consume( ConsumeContext<CustomerCreatedEvent> context )
    {
        logger.LogInformation("Created Customer {CustomerId}", context.Message.CustomerId);
        return Task.CompletedTask;
    }
}