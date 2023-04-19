using Serilog;
using Template.Application;
using Template.Infrastructure;
using Template.Persistence;
using Template.Presentation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Host.UseSerilog((context, services, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services
    .AddApplicationServices()
    .AddPersistenceServices()
    .AddInfrastructureServices()
    .AddPresentationServices();

var app = builder.Build();

app.UsePersistenceServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


