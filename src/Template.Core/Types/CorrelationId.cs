using System.Text.Json.Serialization;

namespace Template.Core.Types;

public readonly record struct CorrelationId
{
    public string Id { get; private init; }
    
    [JsonConstructor]
    private CorrelationId(string correlationId) => Id = correlationId;

    public static CorrelationId Create(string? correlationId = null) 
        => new(correlationId ?? Guid.CreateVersion7().ToString("N"));
};