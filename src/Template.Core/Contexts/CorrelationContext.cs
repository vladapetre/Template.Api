using Template.Core.Types;

namespace Template.Core.Contexts;

public sealed record class CorrelationContext
{
    public CorrelationId CorrelationId { get; set; } = Types.CorrelationId.Create();
    private CorrelationContext(){}
    
    internal static readonly CorrelationContext Create = new();
}