using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A First in First Out Collection
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T> : IEnumerable<T>
{
    // The queued items - the las list item is the newest queue items,
    // the First is the oldest
    // this is so LinkedList<T>.GetEnumerator "just works"
    LinkedList<T> _items = new LinkedList<T>();

    /// <summary>
    /// Adds an item to the back of the queue
    /// </summary>
    /// <param name="item">The item to place in the queue</param>
    public void Enqueue(T item)
    {
        _items.AddLast(item);
    }

    /// <summary>
    /// Removes and return the front item from the queue
    /// </summary>
    /// <returns></returns>
    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("the queue is empty");
        }

        // Store the last value in the temporary variable
        T value = _items.First.Value;

        _items.RemoveFirst();

        return value;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidCastException("the queue is empty");
        }

        return _items.First.Value;
    }

    public int Count
    {
        get { return _items.Count; }
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