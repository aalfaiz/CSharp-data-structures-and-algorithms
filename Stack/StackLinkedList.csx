using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private LinkedList<T> _list = new LinkedList<T>();

    public void Push(T item)
    {
        _list.AddFirst(item);
    }

    public T Pop()
    {
        if (_list.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty");
        }

        T value = _list.First.Value;
        _list.RemoveFirst();

        return value;
    }

    public int Count
    {
        get
        {
            return _list.Count;
        }
    }

    public void Clear()
    {
        _list.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }
}