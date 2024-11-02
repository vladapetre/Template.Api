using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Template.Monitoring.Components.Processors;

public class EnrichLogsWithExceptionProcessor : BaseProcessor<LogRecord>
{
        public EnrichLogsWithExceptionProcessor()
        {
        }

        public override void OnEnd(LogRecord logRecord)
        {
            if (logRecord.Exception == null)
            {
                return;
            }

            logRecord.Attributes = logRecord!.Attributes!.Append(new KeyValuePair<string, object?>("exception.stacktrace", logRecord!.Exception!.StackTrace)).ToList();
            logRecord.Attributes = logRecord!.Attributes!.Append(new KeyValuePair<string, object?>("exception.innerexception", logRecord!.Exception!.InnerException!)).ToList();
        }
}