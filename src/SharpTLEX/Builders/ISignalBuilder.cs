using SharpTLEX.Core;

namespace SharpTLEX.Builders;

internal interface ISignalBuilder : IBuilder<Signal>
{
    ISignalBuilder SetId(int id);
    ISignalBuilder SetContent(string content);
}
