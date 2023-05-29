using System.Text.Json.Serialization;

namespace Template.Domain.Primitives;

public abstract class IEntity
{
    int? _requestedHashCode;
    int _id;
    public virtual int Id
    {
        get
        {
            return _id;
        }
        protected set
        {
            _id = value;
        }
    }

    private List<IEvent> _events = new();

    [JsonIgnore]
    public IReadOnlyCollection<IEvent> Events => _events.AsReadOnly();

    internal void AddEvent(IEvent @event)
    {
        if (_events is null) _events = new();
        _events.Add(@event);
    }

    internal void RemoveEvent(IEvent @event)
    {
        _events.Remove(@event);
    }

    public void ClearEvents()
    {
        _events.Clear();
    }

    public bool IsTransient()
    {
        return Id == default;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not IEntity)
            return false;

        if (Object.ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        IEntity item = (IEntity)obj;

        if (item.IsTransient() || IsTransient())
            return false;
        else
            return item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }
    public static bool operator ==(IEntity left, IEntity right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(IEntity left, IEntity right)
    {
        return !(left == right);
    }
}
