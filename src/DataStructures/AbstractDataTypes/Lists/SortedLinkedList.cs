using System.Collections;

namespace DataStructures.AbstractDataTypes.Lists;

public class SortedLinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public Node(T value)
        {
            Value = value;
            Next = null;
        }

        public Node? Next { get; set; }
        public T Value { get; }
    }

    private Node? Head { get; set; }

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public void Add(T value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));
        
        var newNode = new Node(value);
        var comparer = Comparer<T>.Default;
        
        if (Head is null || comparer.Compare(Head.Value, newNode.Value) >= 0)
        {
            newNode.Next = Head;
            Head = newNode;
            Count++;
            return;
        }

        var current = Head;
        while (current.Next != null && comparer.Compare(current.Next.Value, newNode.Value) < 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;

        Count++;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    public T? Remove(int index)
    {
        if(Head is null || index < 0 || index >= Count)
            return default(T);

        T? node;
        if (index == 0)
        {
            node = Head.Value;
            Head = Head.Next;
        }
        else
        {
            var current = Head;
            var prev = Head;
            var i = 0;
            while (current is not null && i < index)
            {
                prev = current;
                current = current.Next;
                i++;
            }

            node = current!.Value;
            prev.Next = current!.Next;
        }

        Count--;
        return node;
    }

    public void RemoveLast()
    {
        Remove(Count - 1);
    }

    public void RemoveFirst()
    {
        Remove(0);
    }
    
    public bool RemoveValue(T value)
    {
        if (Head is null)
            return false;
        
        var comparer = EqualityComparer<T>.Default;
        if (comparer.Equals(Head.Value, value))
        {
            Head = Head.Next;
            
            Count--;
            return true;
        }
        
        var current = Head;
        var prev = Head;
        while (current is not null)
        {
            if (comparer.Equals(current.Value, value))
            {
                prev.Next = current.Next;
                
                Count--;
                return true;
            }

            prev = current;
            current = current.Next;
        }

        return false;
    }

    public T this[int index]
    {
        get
        {
            if (Head is null || index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Out of range");

            var i = 0;
            var current = Head;
            while (i != index && current is not null)
            {
                current = current.Next;
                
                i++;
            }

            return current!.Value;
        }
    }
    
    private Node? Find(T value)
    {
        if (Head is null)
            return null;

        var current = Head;
        var comparer = EqualityComparer<T>.Default;
        while (current is not null)
        {
            if (comparer.Equals(current.Value, value))
                return current;

            current = current.Next;
        }

        return null;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        if (Head is null)
            yield break;

        var current = Head;
        while (current is not null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}