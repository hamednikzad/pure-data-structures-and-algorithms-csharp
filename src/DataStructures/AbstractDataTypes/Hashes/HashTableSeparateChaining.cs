namespace DataStructures.AbstractDataTypes.Hashes;

public class HashTableSeparateChaining<T>
{
    private const int LoadFactor = 20;
    private readonly int _size;
    private int _count;
    private readonly HashNode[] _hashNodes;
    
    private class Node
    {
        public int Key;
        public T Data;
        public Node? Next;
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
    
    public HashTableSeparateChaining(int size)
    {
        _size = size;
        _count = 0;
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
            if (comparer.Equals(temp.Data,data))
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
        var temp = _hashNodes[index].Next;
        var newNode = new Node
        {
            Data = data,
            Key = index,
            Next = _hashNodes[index].Next
        };
        _hashNodes[index].Count++;
        _hashNodes[index].Next = newNode;
        _count++;
        if (_count / _size > LoadFactor)
            ReHash();
        
        return true;
    }

    private void ReHash()
    {
        throw new NotImplementedException();
    }
}