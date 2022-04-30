using SharpTLEX.Core;
using SharpTLEX.Exceptions;

namespace SharpTLEX.Builders;

internal class SignalBuilder : ISignalBuilder
{
    public Signal Build()
    {
        MissingNonOptionalPropertyException.ThrowIfMissing(Id, nameof(Id));
        MissingNonOptionalPropertyException.ThrowIfMissing(Content, nameof(Content));

        return new Signal((int)Id!, Content!);
    }

    public int? Id { get; private set; }
    public string? Content { get; private set; }

    public ISignalBuilder SetId(int id)
    {
        Id = id;
        return this;
    }

    public ISignalBuilder SetContent(string content)
    {
        Content = content;
        return this;
    }
}
