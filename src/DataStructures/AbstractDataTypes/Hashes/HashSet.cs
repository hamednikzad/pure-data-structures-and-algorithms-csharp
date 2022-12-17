namespace DataStructures.AbstractDataTypes.Hashes;

public class HashSet<T>
{
    private struct Entry
    {
        public int hashCode;
        public int Next;
        public T Value;
    }
    
    private Entry[] _entries;
    private int[]? _buckets;
    private int _size;
    private int _capacity;

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

    private static int GetHash(T item)
    {
        return item!.GetHashCode();
    }

    public bool Add(T item)
    {
        if (item is null)
            return false;

        if (_buckets is null)
        {
            Initialize(0);
        }
        
        var hashCode = GetHash(item);
        var bucket = GetBucket(hashCode);
        
        
        
        
        Count++;
        return true;
    }

    private int GetBucket(int hashCode)
    {
        return _buckets![(uint)hashCode % (uint)_buckets.Length];
    }

    public bool Contains(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        var index = GetHash(item);

        var itemAtIndex = _entries[index];
        
        return itemAtIndex is not null && comparer.Equals(itemAtIndex, item);
    }

    public bool Remove(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        var index = GetHash(item);

        var itemAtIndex = _entries[index];

        if (itemAtIndex is not null && comparer.Equals(itemAtIndex, item))
        {
            _entries[index] = default;
            Count--;
            return true;
        }

        return false;
    }
}