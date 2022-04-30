namespace SharpTLEX.Core;

internal interface IEventBuilder : IBuilder<Event>
{
    IEventBuilder SetId(int id);
    IEventBuilder SetEventClass(EventClass eventClass);
    IEventBuilder SetStem(string stem);
}
