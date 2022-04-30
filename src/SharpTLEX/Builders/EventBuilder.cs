using SharpTLEX.Core;
using SharpTLEX.Exceptions;

namespace SharpTLEX.Builders;

internal class EventBuilder : IEventBuilder
{
    public Event Build()
    {
        MissingNonOptionalPropertyException.ThrowIfMissing(Id, nameof(Id));
        MissingNonOptionalPropertyException.ThrowIfMissing(EventClass, nameof(EventClass));

        return new Event((int)Id!, EventClass!){Stem = Stem};
    }

    public int? Id { get; private set; }
    public EventClass? EventClass { get; private set; }
    public string? Stem { get; private set; }

    public IEventBuilder SetId(int id)
    {
        Id = id;
        return this;
    }

    public IEventBuilder SetEventClass(EventClass eventClass)
    {
        EventClass = eventClass;
        return this;
    }

    public IEventBuilder SetStem(string? stem)
    {
        Stem = stem;
        return this;
    }
}
