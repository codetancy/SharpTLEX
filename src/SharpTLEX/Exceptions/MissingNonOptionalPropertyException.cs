namespace SharpTLEX.Exceptions;

public class MissingNonOptionalPropertyException : Exception
{
    private const string StringTemplate = "Property {0} must be specified.";

    public MissingNonOptionalPropertyException()
    {
    }

    public MissingNonOptionalPropertyException(string propertyName)
        : base(string.Format(StringTemplate, propertyName))
    {
    }

    public static void ThrowIfMissing(object? argument, string? propertyName = null)
    {
        if (argument is null)
        {
            Throw(propertyName);
        }
    }

    private static void Throw(string? propertyName)
    {
        if (propertyName is null)
            throw new MissingNonOptionalPropertyException();

        throw new MissingNonOptionalPropertyException(propertyName);

    }
}
