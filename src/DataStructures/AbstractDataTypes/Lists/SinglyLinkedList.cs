using System.Collections;

namespace DataStructures.AbstractDataTypes.Lists;

public class SinglyLinkedList<T> : IEnumerable<T>
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

    private Node? _head;
    private int _count;

    public Node? Head => _head;
    public int Count => _count;
    public bool IsEmpty => _count == 0;
    
    public void AddFirst(T value)
    {
        var newNode = new Node(value);

        if (_head is null)
        {
            _head = newNode;
            _count++;
            return;
        }

        newNode.Next = _head;
        _head = newNode;
        _count++;
    }

    public void AddLast(T value)
    {
        var newNode = new Node(value);

        if (_head is null)
        {
            _head = newNode;
            _count++;
            return;
        }

        var current = _head;
        while (current.Next is not null)
        {
            current = current.Next;
        }

        current.Next = newNode;
        _count++;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    public T? Remove(int index)
    {
        if(_head is null || index < 0 || index >= _count)
            return default(T);

        T? node;
        if (index == 0)
        {
            node = _head.Value;
            _head = _head.Next;
        }
        else
        {
            var current = _head;
            var prev = _head;
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

        _count--;
        return node;
    }

    public T this[int index]
    {
        get
        {
            if (_head is null || index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Out of range");

            var i = 0;
            var current = _head;
            while (i != index && current is not null)
            {
                current = current.Next;
                
                i++;
            }

            return current!.Value;
        }
    }
    
    public bool RemoveValue(T value)
    {
        if (_head is null)
            return false;
        
        var comparer = EqualityComparer<T>.Default;
        if (comparer.Equals(_head.Value, value))
        {
            _head = _head.Next;
            _count--;
            return true;
        }
        
        var current = _head;
        var prev = _head;
        while (current is not null)
        {
            if (comparer.Equals(current.Value, value))
            {
                prev.Next = current.Next;
                _count--;
                return true;
            }

            prev = current;
            current = current.Next;
        }

        return false;
    }
    
    private Node? Find(T value)
    {
        if (_head is null)
            return null;

        var current = _head;
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
        if (_head is null)
            yield break;

        var current = _head;
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