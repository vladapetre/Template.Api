using Template.Messaging.Worker;
using Template.Messaging.Worker.Components.Customers.Consumers;
using Template.Transaction;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransaction(builder.Configuration, ( cfg ) =>
{
    cfg.AddConsumer<CustomerCreatedConsumer>();
});

builder.Services.AddSerilog(( context, config ) =>
{
    config.ReadFrom.Configuration(builder.Configuration);
    config.Enrich.FromLogContext();
});

var host = builder.Build();
host.Run();
