namespace SharpTLEX.Core;

internal interface IBuilder<T> where T : class
{
    T Build();
}
