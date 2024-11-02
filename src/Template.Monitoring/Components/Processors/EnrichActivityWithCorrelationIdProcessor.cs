using System.Diagnostics;
using OpenTelemetry;
using Template.Core.Contexts;

namespace Template.Monitoring.Components.Processors;

public class EnrichActivityWithCorrelationIdProcessor : BaseProcessor<Activity>
{
    private readonly CorrelationContext correlationContext;

    public EnrichActivityWithCorrelationIdProcessor(CorrelationContext correlationContext)
    {
        this.correlationContext = correlationContext;
    }
    
    public override void OnEnd(Activity activity)
    {
       activity?.AddTag("correlation.id", correlationContext.CorrelationId.Id);
    }
}