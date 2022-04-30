namespace SharpTLEX.Core;

internal class EventBuilder : IEventBuilder
{
    public Event Build()
    {
        if (Id is null)
            throw new Exception();

        if (EventClass is null)
            throw new Exception();

        return new Event((int)Id, EventClass, Stem);
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
