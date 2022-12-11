using System.Collections;
// ReSharper disable All

namespace DataStructures.AbstractDataTypes.Lists;

public class NikArrayList
{
    private object?[] _items;
    private int _size;
    private int _capacity;

    public int Count => _size;

    public int Capacity => _capacity;

    public NikArrayList()
    {
        _items = Array.Empty<object>();
        _capacity = 0;
    }

    public NikArrayList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Should be non negative");

        _items = capacity == 0 ? Array.Empty<object>() : new object[capacity];

        _capacity = capacity;
    }

    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index), "Out of range");

            return _items[index]!;
        }
        set
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index), "Out of range");

            _items[index] = value;
        }
    }

    public int Add(object value)
    {
        if (_size == _items.Length) CheckCapacity(_size + 1);
        _items[_size] = value;
        return _size++;
    }

    private void CheckCapacity(int size)
    {
        if (_items.Length >= size)
            return;
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        if ((uint) newCapacity > Array.MaxLength) newCapacity = Array.MaxLength;
        if (newCapacity < size) newCapacity = size;

        ChangeCapacity(newCapacity);
    }

    private void ChangeCapacity(int newCapacity)
    {
        if (newCapacity < _size)
            throw new ArgumentOutOfRangeException(nameof(newCapacity), "Out of range");

        if (newCapacity == _capacity)
            return;

        if (newCapacity > 0)
        {
            var newItems = new object[newCapacity];

            if (_size > 0)
            {
                Array.Copy(_items, 0, newItems, 0, _size);
            }

            _items = newItems;
        }
        else
        {
            _items = Array.Empty<object>();
        }

        _capacity = newCapacity;
    }

    public void Clear()
    {
        if (_size <= 0) return;

        Array.Clear(_items, 0, _size);
        _size = 0;
    }

    public bool Contains(object? item)
    {
        if (item == null)
        {
            for (var i = 0; i < _size; i++)
                if (_items[i] is null)
                    return true;

            return false;
        }
        else
        {
            for (var i = 0; i < _size; i++)
                if (_items[i] is { } o && o.Equals(item))
                    return true;

            return false;
        }
    }

    public int IndexOf(object? value)
    {
        return Array.IndexOf((Array) _items, value, 0, _size);
    }

    public int IndexOf(object? value, int startIndex)
    {
        if (startIndex > _size)
            throw new ArgumentOutOfRangeException(nameof(startIndex));

        return Array.IndexOf((Array) _items, value, startIndex, _size - startIndex);
    }

    public int IndexOf(object? value, int startIndex, int count)
    {
        if (startIndex > _size)
            throw new ArgumentOutOfRangeException(nameof(startIndex));

        if (count < 0 || startIndex > _size - count)
            throw new ArgumentOutOfRangeException(nameof(count));

        return Array.IndexOf((Array) _items, value, startIndex, count);
    }

    public void Insert(int index, object? value)
    {
        if (index < 0 || index > _size)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (_size == _items.Length) CheckCapacity(_size + 1);
        if (index < _size)
        {
            Array.Copy(_items, index, _items, index + 1, _size - index);
        }

        _items[index] = value;
        _size++;
    }

    public void InsertRange(int index, ICollection c)
    {
        if (c == null)
            throw new ArgumentNullException(nameof(c));

        if (index < 0 || index > _size)
            throw new ArgumentOutOfRangeException(nameof(index));

        int count = c.Count;
        if (count > 0)
        {
            CheckCapacity(_size + count);

            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + count, _size - index);
            }

            var itemsToInsert = new object[count];
            c.CopyTo(itemsToInsert, 0);
            itemsToInsert.CopyTo(_items, index);
            _size += count;
        }
    }

    public int LastIndexOf(object? value)
    {
        return LastIndexOf(value, _size - 1, _size);
    }

    public int LastIndexOf(object? value, int startIndex)
    {
        if (startIndex >= _size)
            throw new ArgumentOutOfRangeException(nameof(startIndex));

        return LastIndexOf(value, startIndex, startIndex + 1);
    }

    public int LastIndexOf(object? value, int startIndex, int count)
    {
        if (Count != 0 && (startIndex < 0 || count < 0))
            throw new ArgumentOutOfRangeException(startIndex < 0 ? nameof(startIndex) : nameof(count));

        if (_size == 0)
            return -1;

        if (startIndex >= _size || count > startIndex + 1)
            throw new ArgumentOutOfRangeException(startIndex >= _size ? nameof(startIndex) : nameof(count));

        return Array.LastIndexOf((Array) _items, value, startIndex, count);
    }

    public void Remove(object? obj)
    {
        int index = IndexOf(obj);
        if (index >= 0)
            RemoveAt(index);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
            throw new ArgumentOutOfRangeException(nameof(index));

        _size--;
        if (index < _size)
        {
            Array.Copy(_items, index + 1, _items, index, _size - index);
        }

        _items[_size] = null;
    }

    public void RemoveRange(int index, int count)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        if (_size - index < count)
            throw new ArgumentException("Invalid length for remove");

        if (count <= 0) return;
        
        var i = _size;
        _size -= count;
        if (index < _size)
        {
            Array.Copy(_items, index + count, _items, index, _size - index);
        }

        while (i > _size) _items[--i] = null;
    }

    public object?[] ToArray()
    {
        if (_size == 0)
            return Array.Empty<object>();

        object?[] array = new object[_size];
        Array.Copy(_items, array, _size);
        return array;
    }
}