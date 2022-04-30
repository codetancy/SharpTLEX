namespace SharpTLEX.Builders;

internal interface IBuilder<T> where T : class
{
    T Build();
}
