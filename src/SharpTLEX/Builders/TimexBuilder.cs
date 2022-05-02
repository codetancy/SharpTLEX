using SharpTLEX.Core;
using SharpTLEX.Exceptions;

namespace SharpTLEX.Builders;

internal class TimexBuilder : ITimexBuilder
{
    public Timex Build()
    {
        MissingNonOptionalPropertyException.ThrowIfMissing(Id, nameof(Id));
        MissingNonOptionalPropertyException.ThrowIfMissing(Phrase, nameof(Phrase));
        MissingNonOptionalPropertyException.ThrowIfMissing(TimexType, nameof(TimexType));
        MissingNonOptionalPropertyException.ThrowIfMissing(Value, nameof(Value));
        MissingNonOptionalPropertyException.ThrowIfMissing(TemporalFunction, nameof(TemporalFunction));

        return new Timex((int)Id!, TimexType!, Value!, (bool)TemporalFunction!, Phrase!)
        {
            Mod = Mod,
            FunctionInDocument = FunctionInDocument,
            AnchorTimeId = AnchorTimeId,
            BeginPointId = BeginPointId,
            EndPointId = EndPointId,
            Quantification = Quantification,
            Frequency = Frequency
        };
    }

    public int? Id { get; private set; }

    public string? Phrase { get; private set; }

    public TimexType? TimexType { get; private set; }

    public string? Value { get; private set; }

    public bool? TemporalFunction { get; private set; }

    public Mod? Mod { get; private set; }

    public FunctionInDocument? FunctionInDocument { get; private set; }

    public int? AnchorTimeId { get; private set; }

    public int? BeginPointId { get; private set; }

    public int? EndPointId { get; private set; }

    public string? Quantification { get; private set; }

    public string? Frequency { get; private set; }

    public ITimexBuilder SetId(int id)
    {
        Id = id;
        return this;
    }

    public ITimexBuilder SetPhrase(string phrase)
    {
        Phrase = phrase;
        return this;
    }

    public ITimexBuilder SetTimexType(TimexType timexType)
    {
        TimexType = timexType;
        return this;
    }

    public ITimexBuilder SetValue(string value)
    {
        Value = value;
        return this;
    }

    public ITimexBuilder SetTemporalFunction(bool temporalFunction)
    {
        TemporalFunction = temporalFunction;
        return this;
    }

    public ITimexBuilder SetMod(Mod mod)
    {
        Mod = mod;
        return this;
    }

    public ITimexBuilder SetFunctionInDocument(FunctionInDocument functionInDocument)
    {
        FunctionInDocument = functionInDocument;
        return this;
    }

    public ITimexBuilder SetAnchorTimeId(int anchorTimeId)
    {
        AnchorTimeId = anchorTimeId;
        return this;
    }

    public ITimexBuilder SetBeginPointId(int beginPointId)
    {
        BeginPointId = beginPointId;
        return this;
    }

    public ITimexBuilder SetEndPointId(int endPointId)
    {
        EndPointId = endPointId;
        return this;
    }

    public ITimexBuilder SetQuantification(string quantification)
    {
        Quantification = quantification;
        return this;
    }

    public ITimexBuilder SetFrequency(string frequency)
    {
        Frequency = frequency;
        return this;
    }
}
