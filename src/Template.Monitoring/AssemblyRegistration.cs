using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Template.Monitoring.Components.Processors;
using Sdk = OpenTelemetry.Sdk;

namespace Template.Monitoring;

public static class AssemblyRegistration
{
    public static IServiceCollection AddMonitoring( this IServiceCollection services , IHostEnvironment environment )
    {
        using var meterProvider = Sdk.CreateMeterProviderBuilder()
            .AddRuntimeInstrumentation()
            .AddProcessInstrumentation()
            .Build();

        services.AddOpenTelemetry()
            .ConfigureResource(config =>
            {
                config.AddService(Assembly.GetEntryAssembly()?.GetName()?.Name!,
                    serviceNamespace: environment.EnvironmentName,
                    serviceInstanceId: Environment.MachineName);
            })
            .WithTracing(builder =>
            {
                builder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation()
                    .AddConsoleExporter()
                    .AddOtlpExporter(options => { options.Endpoint = new Uri("http://jaeger:4317"); });

                builder.AddProcessor<EnrichActivityWithCorrelationIdProcessor>();
            })
            .WithLogging(builder =>
            {
                builder.AddConsoleExporter();
                
                builder.AddProcessor<EnrichLogsWithCorrelationIdProcessor>();
                builder.AddProcessor<EnrichLogsWithExceptionProcessor>();

            }, options =>
            {
                
            });

        return services;
    }
}