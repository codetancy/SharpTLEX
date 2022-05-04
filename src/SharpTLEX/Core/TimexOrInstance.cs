using OneOf;

namespace SharpTLEX.Core;

public class TimexOrInstance : OneOfBase<Timex, Instance>
{
    protected TimexOrInstance(OneOf<Timex, Instance> input) : base(input)
    {
    }

    public static implicit operator TimexOrInstance(Timex timex) => new TimexOrInstance(timex);
    public static explicit operator Timex(TimexOrInstance timexOrInstance) => timexOrInstance.AsT0;

    public static implicit operator TimexOrInstance(Instance instance) => new TimexOrInstance(instance);
    public static explicit operator Instance(TimexOrInstance timexOrInstance) => timexOrInstance.AsT1;
}
