using System.Collections.Generic;

namespace St2D.Collections
{
    public class LazyList<T> : List<T>, ILazyList<T>
    {
        protected Queue<T> addQueue;
        protected Queue<T> removeQueue;

        public LazyList()
        {
            addQueue = new Queue<T>();
            removeQueue = new Queue<T>();
        }

        public virtual void LazyAdd(T item)
        {
            addQueue.Enqueue(item);
        }

        public virtual void LazyRemove(T item)
        {
            removeQueue.Enqueue(item);
        }

        public virtual void Apply()
        {
            while (addQueue.Count > 0)
                base.Add(addQueue.Dequeue());

            while (removeQueue.Count > 0)
                base.Remove(removeQueue.Dequeue());
        }
    }
}