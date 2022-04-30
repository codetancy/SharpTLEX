namespace SharpTLEX.Core;

public class Event : ICloneable, IEquatable<Event?>
{
    public Event(int id, EventClass eventClass, string? stem = null)
    {
        Id = id;
        EventClass = eventClass;
        Stem = stem;
    }

    public int Id { get; }

    public string StrId => "e" + Id;

    public EventClass EventClass { get; }

    public string? Stem { get; }

    public static bool operator ==(Event? e1, Event? e2)
    {
        if (e1 is null)
            return e2 is null;

        return e1.Equals(e2);
    }

    public static bool operator !=(Event? e1, Event? e2) => !(e1 == e2);

    public bool Equals(Event? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id == other.Id && EventClass.Equals(other.EventClass) && Stem == other.Stem;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        return Equals((Event) obj);
    }

    public override int GetHashCode() => HashCode.Combine(Id, EventClass.Value, Stem);

    public object Clone() => new Event(Id, EventClass, Stem);
}
