using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Infrastructure.Http.Correlation;
public interface ICorrelationService
{
    public string GetCorrelationId();
    public void SetCorrelationId(string correlationId);
}
