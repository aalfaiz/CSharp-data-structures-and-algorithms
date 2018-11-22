using System.Collections;
using System.Collections.Generic;

#region Reference
public class LinkedListNode<T>
{
    public T Value { get; set; }
    public LinkedListNode(T value)
    {
        Value = value;
    }

    public LinkedListNode<T> Next { get; set; }
}

#endregion

public class LinkedList<T> : System.Collections.Generic.ICollection<T>
{
    public LinkedListNode<T> Head
    {
        get;
        private set;
    }

    public LinkedListNode<T> Tail
    {
        get;
        private set;
    }

    #region Add
    public void AddLast(T value)
    {
        AddLast(new LinkedListNode<T>(value));
    }

    public void AddLast(LinkedListNode<T> node)
    {
        if (Count == 0)
        {
            Head = node;

        }
        else
        {
            Tail.Next = node;
        }
        Tail = node;
    }

    public void AddFirst(T value)
    {
        AddFirst(new LinkedListNode<T>(value));
    }

    public void AddFirst(LinkedListNode<T> node)
    {
        LinkedListNode<T> temp = Head;
        Head = node;
        Head.Next = temp;

        Count++;

        if (Count == 1)
        {
            Tail = Head;
        }

    }
    #endregion

    #region Remove
    public void RemoveFirst()
    {
        Head = Head.Next;
        Count--;

        if (Count == 0)
        {
            Tail = null;
        }
    }

    public void RemoveLast()
    {
        if (Count != 0)
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                // Before: Head --> 3 --> 5 --> 7
                //         Tail = 7    
                // After : Head --> 3 --> 5 --> 7
                //         Tail = 5 

                LinkedListNode<T> current = Head;
                while (current != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                Tail = current;
            }
            Count--;
        }
    }
    #endregion

    #region ICollection
    public int Count { get; private set; }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }


    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        LinkedListNode<T> current = Head;
        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        LinkedListNode<T> current = Head;
        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        LinkedListNode<T> current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public void Add(T item)
    {
        AddFirst(item);
    }

    public bool Remove(T item)
    {
        LinkedListNode<T> previous = null;
        LinkedListNode<T> current = Head;

        // 1: Empty list - do nothing
        // 2: Sinle node : previous is null
        // 3: Many nodes
        //      a: node to remove is the first node
        //      b: node to remove is the middle or last

        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                // it's a node in the middle or end
                if (previous != null)
                {
                    previous.Next = current.Next;

                    // it was the end - so update tail
                    if (current.Next == null)
                    {
                        Tail = previous;
                    }
                    Count--;
                }
                else
                {
                    // case 2 or 3a
                    RemoveFirst();
                }

                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
    }


    #endregion

}