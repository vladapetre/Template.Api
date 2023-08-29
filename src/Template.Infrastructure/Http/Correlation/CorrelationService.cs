using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Infrastructure.Http.Correlation;
internal class CorrelationService : ICorrelationService
{
    private string _correlationId = Guid.NewGuid().ToString();
    public string GetCorrelationId() => _correlationId;
    public void SetCorrelationId(string correlationId) => _correlationId = correlationId;
}
