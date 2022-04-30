using SharpTLEX.Core;

namespace SharpTLEX.Builders;

internal interface IEventBuilder : IBuilder<Event>
{
    IEventBuilder SetId(int id);
    IEventBuilder SetEventClass(EventClass eventClass);
    IEventBuilder SetStem(string? stem);
}
