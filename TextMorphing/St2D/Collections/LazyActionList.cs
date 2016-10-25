using System;
using System.Collections.Generic;

namespace St2D.Collections
{
    public class LazyActionList<T> : LazyList<T>
    {
        private Queue<Action<T>> addActionQueue;
        private Queue<Action<T>> removeActionQueue;

        public LazyActionList()
        {
            addActionQueue = new Queue<Action<T>>();
            removeActionQueue = new Queue<Action<T>>();
        }

        public override void LazyAdd(T item)
        {
            this.LazyAdd(item, null);
        }

        public override void LazyRemove(T item)
        {
            this.LazyRemove(item, null);
        }

        public void LazyAdd(T item, Action<T> addAction)
        {
            base.LazyAdd(item);
            addActionQueue.Enqueue(addAction);
        }

        public void LazyRemove(T item, Action<T> removeAction)
        {
            base.LazyRemove(item);
            removeActionQueue.Enqueue(removeAction);
        }

        public override void Apply()
        {
            while (addQueue.Count > 0)
            {
                var itm = addQueue.Dequeue();
                var act = addActionQueue.Dequeue();

                this.Add(itm);
                act?.Invoke(itm);
            }

            while (removeQueue.Count > 0)
            {
                var itm = removeQueue.Dequeue();
                var act = removeActionQueue.Dequeue();

                this.Remove(itm);
                act?.Invoke(itm);
            }
        }
    }
}
