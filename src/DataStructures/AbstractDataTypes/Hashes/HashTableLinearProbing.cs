using System.Collections;

namespace DataStructures.AbstractDataTypes.Hashes;

public class HashTableLinearProbing<T> : IEnumerable<T>
{
    private class Item
    {
        public readonly T Data;

        public Item(T data)
        {
            Data = data;
        }
    }
    
    private int _size;
    private int _free;
    private Item?[] _entries;
    public int Count { get; private set; }

    public HashTableLinearProbing()
    {
        _size = 20;
        _free = _size;
        _entries = new Item[_size];
    }

    public HashTableLinearProbing(int size)
    {
        _size = size;
        _free = size;
        _entries = new Item[_size];
    }

    private static int GetHash(T item)
    {
        return item!.GetHashCode();
    }

    private int GetHashIndex(T item)
    {
        return GetHash(item) % _size;
    }

    public bool Contains(T data)
    {
        var index = GetHashIndex(data);
        var comparer = EqualityComparer<T>.Default;

        for (var i = 0; i < _size; i++)
        {
            var index2 = (i + index) % _size;
            var item = _entries[index2];
            if (item is not null && comparer.Equals(item.Data, data))
                return true;
        }

        return false;
    }

    public void Remove(T data)
    {
        var index = GetHashIndex(data);
        var comparer = EqualityComparer<T>.Default;

        for (var i = 0; i < _size; i++)
        {
            var index2 = (i + index) % _size;
            var item = _entries[index2];
            if (item is not null && !comparer.Equals(item.Data, data)) continue;
            
            _entries[index2] = null;
            Count--;
            return;
        }
    }

    public bool Add(T data)
    {
        if (Contains(data))
            return false;

        if (_free <= 0)
            Expand();

        var index = GetHashIndex(data);
        for (var i = 0; i < _size; i++)
        {
            var index2 = (i + index) % _size;
            if (_entries[index2] is not null) continue;

            _entries[index2] = new Item(data);
            Count++;
            _free--;
            return true;
        }

        return false;
    }

    private void Expand()
    {
        var newSize = _size * 2;
        var newEntries = new Item?[newSize];
        var newFree = newSize;
        var count = 0;
        for (var i = 0; i < _size; i++)
        {
            var item = _entries[i];
            if(item is null)
                continue;

            var hash = GetHash(item.Data);
            var index = hash % newSize;
            for (var j = 0; j < newSize; j++)
            {
                var index2 = (j + index) % newSize;
                if (newEntries[index2] is not null) continue;

                newEntries[index2] = item;
                count++;
                newFree--;
                break;
            }
        }
        
        _size = newSize;
        _entries = newEntries;
        _free = newFree;
        Count = count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < _size; i++)
        {
            var item = _entries[i];
            if (item is not null)
                yield return item.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}