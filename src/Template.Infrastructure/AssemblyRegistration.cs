using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Models.Example;
using Template.Infrastructure.Example.Mappers;
using Template.Infrastructure.Http.Client;
using Template.Infrastructure.Http.Client.Handlers;
using Template.Infrastructure.Http.Correlation;
using Template.Infrastructure.Mappers;

namespace Template.Infrastructure;

public static class AssemblyRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        services.AddTransient<IMapper<ExampleAggregateRoot, object>, ExampleToObjectMapper>();

        services.AddHttpClient<IHttpClient>()
            .AddHttpMessageHandler<HttpClientRetryHandler>()
            .AddHttpMessageHandler<HttpClientCircuitBreakerHandler>();


        services.AddScoped<ICorrelationService, CorrelationService>();

        return services;
    }
}
