using Microsoft.AspNetCore.Mvc;
using Template.Application;
using Template.Application.Components.Customers.CreateCustomer;
using Template.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddPersistence();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/customers", async ( [FromBody] CreateCustomerRequest request, ICreateCustomerCommandHandler handler ) =>
{
    var result = await handler.HandlerAsync(new CreateCustomerCommand(request.Name));

    return result.Match(
        ( customer ) => Results.Ok(customer),
        () => Results.BadRequest("stuff happened"));
});

app.Run();

internal sealed record class CreateCustomerRequest( string Name )
{
}