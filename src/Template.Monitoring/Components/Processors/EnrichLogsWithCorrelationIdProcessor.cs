using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Logs;
using Template.Core.Contexts;

namespace Template.Monitoring.Components.Processors;

public class EnrichLogsWithCorrelationIdProcessor: BaseProcessor<LogRecord>
{
    private readonly CorrelationContext correlationContext;

    public EnrichLogsWithCorrelationIdProcessor(CorrelationContext correlationContext)
    {
        this.correlationContext = correlationContext;
    }
    
    public override void OnEnd(LogRecord logRecord)
    {
        logRecord.Attributes = logRecord!.Attributes!.Append(new KeyValuePair<string, object?>("correlation.id", correlationContext.CorrelationId.Id)).ToList();
    }
}