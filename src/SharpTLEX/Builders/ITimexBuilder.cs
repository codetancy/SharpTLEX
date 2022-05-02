using SharpTLEX.Core;

namespace SharpTLEX.Builders;

internal interface ITimexBuilder : IBuilder<Timex>
{
    ITimexBuilder SetId(int id);
    ITimexBuilder SetPhrase(string phrase);
    ITimexBuilder SetTimexType(TimexType timexType);
    ITimexBuilder SetValue(string value);
    ITimexBuilder SetTemporalFunction(bool temporalFunction);
    ITimexBuilder SetMod(Mod mod);
    ITimexBuilder SetFunctionInDocument(FunctionInDocument functionInDocument);
    ITimexBuilder SetAnchorTimeId(int anchorTimeId);
    ITimexBuilder SetBeginPointId(int beginPointId);
    ITimexBuilder SetEndPointId(int endPointId);
    ITimexBuilder SetQuantification(string quantification);
    ITimexBuilder SetFrequency(string frequency);
}
