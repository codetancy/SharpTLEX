using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class EventClass : SmartEnum<EventClass, string>
{
    public static readonly EventClass Reporting = new EventClass(nameof(Reporting), "REPORTING");
    public static readonly EventClass Perception = new EventClass(nameof(Perception), "PERCEPTION");
    public static readonly EventClass Aspectual = new EventClass(nameof(Aspectual), "ASPECTUAL");
    public static readonly EventClass IntentionalAction = new EventClass(nameof(IntentionalAction), "I_ACTION");
    public static readonly EventClass IntentionalState = new EventClass(nameof(IntentionalState), "I_STATE");
    public static readonly EventClass State = new EventClass(nameof(State), "STATE");
    public static readonly EventClass Occurrence = new EventClass(nameof(Occurrence), "OCCURRENCE");

    private EventClass(string name, string value) : base(name, value)
    {
    }
}
