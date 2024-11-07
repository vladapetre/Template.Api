using Serilog;
using Template.Core.Contexts;
using Template.Messaging.Worker.Components.Customers.Consumers;
using Template.Outbox;
using Template.Persistence;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<CorrelationContext>(_ => ContextFactory.CreateCorrelationContext());
builder.Services.AddScoped<SqlConnectionContext>((_) => ContextFactory.CreateSqlConnectionContext("Data Source=../../template.db"));


builder.Services.AddOutbox(builder.Configuration, cfg => { cfg.AddConsumer<CustomerCreatedConsumer>(); });

builder.Services.AddSerilog(( context, config ) =>
{
    config.ReadFrom.Configuration(builder.Configuration);
    config.Enrich.FromLogContext();
});

var host = builder.Build();
host.Run();