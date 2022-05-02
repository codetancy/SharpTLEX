using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class FunctionInDocument : SmartEnum<FunctionInDocument, string>
{
    public static readonly FunctionInDocument CreationTime = new(nameof(CreationTime), "CREATION_TIME");
    public static readonly FunctionInDocument ModificationTime = new(nameof(ModificationTime), "MODIFICATION_TIME");
    public static readonly FunctionInDocument PublicationTime = new(nameof(PublicationTime), "PUBLICATION_TIME");
    public static readonly FunctionInDocument ReleaseTime = new(nameof(ReleaseTime), "RELEASE_TIME");
    public static readonly FunctionInDocument ReceptionTime = new(nameof(ReceptionTime), "RECEPTION_TIME");
    public static readonly FunctionInDocument ExpirationTime = new(nameof(ExpirationTime), "EXPIRATION_TIME");
    public static readonly FunctionInDocument None = new(nameof(None), "NONE");

    private FunctionInDocument(string name, string value) : base(name, value)
    {
    }
}
