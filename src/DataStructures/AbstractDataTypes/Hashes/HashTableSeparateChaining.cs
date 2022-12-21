using System.Collections;

namespace DataStructures.AbstractDataTypes.Hashes;

public class HashTableSeparateChaining<T> : IEnumerable<T>
{
    private const int LoadFactor = 10;
    private int _size;
    private HashNode[] _hashNodes;

    public int Count { get; private set; }

    private class Node
    {
        public readonly T Data;
        public Node? Next;

        public Node(T data, Node? next)
        {
            Data = data;
            Next = next;
        }
    }

    private class HashNode
    {
        public int Count;
        public Node? Next;

        public HashNode()
        {
            Next = null;
        }
    }

    private static int GetHash(T item)
    {
        return item!.GetHashCode();
    }

    private int GetHashIndex(T item)
    {
        return GetHash(item) % _size;
    }
    
    public HashTableSeparateChaining()
    {
        _size = 20;
        Count = 0;
        _hashNodes = new HashNode[_size];

        for (var i = 0; i < _hashNodes.Length; i++)
        {
            _hashNodes[i] = new HashNode();
        }
    }
    
    public HashTableSeparateChaining(int size)
    {
        _size = size;
        Count = 0;
        _hashNodes = new HashNode[size];

        for (var i = 0; i < _hashNodes.Length; i++)
        {
            _hashNodes[i] = new HashNode();
        }
    }

    public bool Contains(T data)
    {
        var hashIndex = GetHashIndex(data);

        var comparer = EqualityComparer<T>.Default;
        var temp = _hashNodes[hashIndex].Next;
        while (temp is not null)
        {
            if (comparer.Equals(temp.Data, data))
                return true;

            temp = temp.Next;
        }

        return false;
    }

    public bool Add(T data)
    {
        if (Contains(data))
            return false;

        var index = GetHashIndex(data);
        var newNode = new Node(data, _hashNodes[index].Next);
        _hashNodes[index].Count++;
        _hashNodes[index].Next = newNode;
        Count++;
        if (Count / _size > LoadFactor)
            ReHash();

        return true;
    }

    public bool Remove(T data)
    {
        var index = GetHashIndex(data);
        var temp = _hashNodes[index].Next;
        var prev = temp;
        if (temp is null || prev is null)
            return false;

        var comparer = EqualityComparer<T>.Default;
        while (temp is not null)
        {
            if (comparer.Equals(temp.Data, data))
            {
                prev.Next = temp.Next;
                Count--;
                _hashNodes[index].Count--;
                return true;
            }

            prev = temp;
            temp = temp.Next;
        }

        return false;
    }

    private void ReHash()
    {
        var lastSize = _size;
        _size *= 2;
        var newHashNodes = new HashNode[_size];
        for (var i = 0; i < _size; i++)
        {
            newHashNodes[i] = new HashNode();
        }

        var innerCount = 0;
        Count = 0;
        for (var i = 0; i < lastSize; i++)
        {
            var temp = _hashNodes[i].Next;
            while (temp is not null)
            {
                var index = GetHashIndex(temp.Data);
                var newNode = new Node(temp.Data, newHashNodes[index].Next);
                newHashNodes[index].Next = newNode;
                newHashNodes[index].Count++;
                Count++;
                temp = temp.Next;
            }

            innerCount += _hashNodes[i].Count;
        }

        if (Count != innerCount)
            throw new ArithmeticException("Count is not calculated correctly");

        _hashNodes = newHashNodes;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < _size; i++)
        {
            var temp = _hashNodes[i].Next;
            while (temp is not null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}