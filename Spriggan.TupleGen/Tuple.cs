namespace Spriggan.TupleGen;

public struct Tuple<T> : ITuple
{
    public EntityId Entity { get; init; }
    public string Attr { get; init; }
    public T Value { get; init; }
}