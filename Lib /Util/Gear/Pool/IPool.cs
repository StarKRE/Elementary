using System.Collections.Generic;

namespace OregoFramework.Util
{
    public interface IPool<T>
    {
        IEnumerable<T> items { get; }

        bool IsEmpty();

        bool IsNotEmpty();

        void Push(T poolObject);

        T Pop();

        T Peek();
    }
}