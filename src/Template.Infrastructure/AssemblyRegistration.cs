using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Models.Example;
using Template.Infrastructure.Example.Mappers;
using Template.Infrastructure.Http.Client;
using Template.Infrastructure.Http.Client.Handlers;
using Template.Infrastructure.Mappers;

namespace Template.Infrastructure;

public static class AssemblyRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddTransient<IMapper<ExampleAggregateRoot, object>, ExampleToObjectMapper>();

        services.AddHttpClient<IHttpClient>()
            .AddHttpMessageHandler<HttpClientRetryHandler>()
            .AddHttpMessageHandler<HttpClientCircuitBreakerHandler>();

        return services;
    }
}
