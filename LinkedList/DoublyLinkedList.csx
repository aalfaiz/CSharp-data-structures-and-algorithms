

#region reference

using System.Collections;
using System.Collections.Generic;

public class LinkedListNode<T>
{
    public LinkedListNode(T value){
        Value = value;
    }

    public T Value {get; set;}
    public LinkedListNode<T> Next {get; set;}
    public LinkedListNode<T> Previous {get;set;}
}
#endregion


public class LinkedList<T> : System.Collections.Generic.ICollection<T>
{
    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}