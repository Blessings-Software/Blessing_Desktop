using System.Collections.Generic;

namespace St2D.Collections
{
    public interface ILazyList<T> : IList<T>
    {
        void LazyAdd(T item);
        void LazyRemove(T item);
        void Apply();
    }
}