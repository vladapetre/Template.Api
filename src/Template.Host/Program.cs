using Template.Application;
using Template.Host.Middleware;
using Template.Transaction;
using Template.Presentation;
using Serilog;
using Template.Core.Contexts;
using Template.Host.Middleware.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<CorrelationContext>((_) => ContextFactory.CreateCorrelationContext());

builder.Services.AddApplication();
builder.Services.AddTransaction(builder.Configuration, null);

builder.Services.AddExceptionHandler<CoreExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddSerilog(( context, config ) =>
{
    config.ReadFrom.Configuration(builder.Configuration);
    config.Enrich.FromLogContext();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();
app.UseMiddleware<CorrelationContextMiddleware>();

app.MapEndpoints();

app.Run();

