using System.Collections;

namespace DataStructures.AbstractDataTypes.Lists;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class Node
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

    public int Count => _count;
    
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

    public void Insert(int index, T value)
    {
        if(_head is null || index < 0 || index > _count)
            return;
        
        var newNode = new Node(value);

        if (index == 0)
        {
            newNode.Next = _head;

            _head = newNode;
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

            newNode.Next = current;

            prev.Next = newNode;
            if (current != null)
            {
            }
        }

        _count++;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    public void Remove(int index)
    {
        if(_head is null || index < 0 || index >= _count)
            return;

        if (index == 0)
        {
            _head = _head.Next;
            if (_head != null)
            {
            }
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
            prev.Next = current!.Next;
        }

        _count--;
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
            if (_head != null)
            {
            }

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