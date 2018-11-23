using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
{
    LinkedList<T> _items = new LinkedList<T>();

    public void Enqueue(T item)
    {
        if (_items.Count == 0)
        {
            _items.AddLast(item);
        }
        else
        {
            // find the proper insert point
            var current = _items.First;

            // while we're not at the end of the list and the current value
            // is larger than value being inserted...
            while (current != null && current.Value.CompareTo(item) > 0)
            {
                current = current.Next;
            }

            if (current == null)
            {
                _items.AddLast(item);
            }
            else
            {
                _items.AddBefore(current, item);
            }

        }
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("the queue is empty");
        }

        T value = _items.First.Value;

        _items.RemoveFirst();

        return value;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        return _items.First.Value;
    }

    public int Count
    {
        get
        {
            return _items.Count;
        }
    }

    public void Clear()
    {
        _items.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}