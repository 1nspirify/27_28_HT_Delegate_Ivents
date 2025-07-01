using System;

public interface IReadOnlyVariable<T>
{
    public event Action<T, T> Changed;
   T Value { get; }
}
 