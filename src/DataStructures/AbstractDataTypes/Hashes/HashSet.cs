namespace DataStructures.AbstractDataTypes.Hashes;

public class HashSet<T>
{
    private struct Entry
    {
        public int HashCode;
        public int Next;
        public T Value;
    }
    
    private Entry[] _entries;
    private int[]? _buckets;
    private int _count;
    private int _capacity;
    private int _freeList;
    private int _freeCount;

    public int Count { get; private set; }
    public int Capacity => _capacity;

    public HashSet()
    {
        _capacity = 0;
    }

    public HashSet(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        if (capacity > 0)
        {
            Initialize(capacity);
        }
    }

    private void Initialize(int capacity)
    {
        _buckets = new int[capacity];
        _entries = new Entry[capacity];
    }

    private void Resize()
    {
        var newSize = _capacity * 2;
        Resize(newSize);
    }
    
    private void Resize(int newSize)
    {
        var newEntries = new Entry[newSize];
        var newBuckets = new int[newSize];
        
        //Copy

        _capacity = newSize;
    }
    
    public bool Add(T item)
    {
        if (item is null)
            return false;

        if (_buckets is null)
        {
            Initialize(0);
        }
        var comparer = EqualityComparer<T>.Default;

        var hashCode = GetHash(item);
        var bucket = GetBucket(hashCode);
        while (bucket >= 0)
        {
            var entry = _entries[bucket];
            if (entry.HashCode == hashCode && comparer.Equals(entry.Value, item))
            {
                //Item already exists
                return false;
            }

            bucket = entry.Next;
        }
        
        int index;
        if (_freeCount > 0)
        {
            index = _freeList;
            _freeCount--;
            //_freeList = StartOfFreeList - entries[_freeList].Next;
            throw new NotImplementedException();
        }
        else
        {
            int count = _count;
            if (count == _entries.Length)
            {
                Resize();
                bucket = GetBucket(hashCode);
            }
            index = count;
            _count = count + 1;
        }

        {
            var entry = _entries![index];
            entry.HashCode = hashCode;
            entry.Next = bucket - 1; // Value in _buckets is 1-based
            entry.Value = item;
            bucket = index + 1;
        }
        
        return true;
    }
    
    private static int GetHash(T item)
    {
        return item!.GetHashCode();
    }
    
    private int GetBucket(int hashCode)
    {
        return _buckets![(uint)hashCode % (uint)_buckets.Length];
    }

    public bool Contains(T item)
    {
        if (_buckets is null || item is null)
            return false;
        
        var comparer = EqualityComparer<T>.Default;

        var hashCode = GetHash(item);
        var bucket = GetBucket(hashCode);
        while (bucket >= 0)
        {
            var entry = _entries[bucket];
            if (entry.HashCode == hashCode && comparer.Equals(entry.Value, item))
            {
                return true;
            }

            bucket = entry.Next;
        }

        return false;
    }

    // public bool Remove(T item)
    // {
    //     var comparer = EqualityComparer<T>.Default;
    //     var index = GetHash(item);
    //
    //     var itemAtIndex = _entries[index];
    //
    //     if (itemAtIndex is not null && comparer.Equals(itemAtIndex, item))
    //     {
    //         _entries[index] = default;
    //         Count--;
    //         return true;
    //     }
    //
    //     return false;
    // }
}