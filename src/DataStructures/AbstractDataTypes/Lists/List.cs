using System.Collections;

// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

namespace DataStructures.AbstractDataTypes.Lists;

public class List<T> : IEnumerable<T>
{
    private T[] _items;
    private int _size;
    private int _capacity;
    private readonly T[] _emptyArray = Array.Empty<T>();

    public int Count => _size;

    public int Capacity => _capacity;

    public List()
    {
        _items = _emptyArray;
        _capacity = 0;
    }

    public List(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Should be non negative");

        _items = capacity == 0 ? _emptyArray : new T[capacity];

        _capacity = capacity;
    }

    public List(IEnumerable<T> collection)
    {
        switch (collection)
        {
            case null:
                throw new ArgumentNullException(nameof(collection));

            case ICollection<T> c:
            {
                var count = c.Count;
                if (count == 0)
                {
                    _items = _emptyArray;
                }
                else
                {
                    _items = new T[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }

                break;
            }
            default:
            {
                _size = 0;
                _items = _emptyArray;

                using var en = collection.GetEnumerator();
                while (en.MoveNext())
                {
                    Add(en.Current);
                }

                break;
            }
        }
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
        if (newCapacity < -_size)
            throw new ArgumentOutOfRangeException(nameof(newCapacity), "Out of range");

        if (newCapacity == _capacity)
            return;

        if (newCapacity > 0)
        {
            var newItems = new T[newCapacity];

            if (_size > 0)
            {
                Array.Copy(_items, 0, newItems, 0, _size);
            }

            _items = newItems;
        }
        else
        {
            _items = _emptyArray;
        }

        _capacity = newCapacity;
    }

    public T this[int index]
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

    public void Clear()
    {
        if (_size <= 0) return;

        Array.Clear(_items, 0, _size);
        _size = 0;
    }

    public void Add(T value)
    {
        if (_size == _items.Length) CheckCapacity(_size + 1);
        _items[_size++] = value;
    }

    public void Insert(int index, T value)
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

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
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

        _items[_size] = default(T) ?? throw new InvalidOperationException();
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

        while (i > _size)
            _items[--i] = default(T) ?? throw new InvalidOperationException();
    }

    public bool Contains(T item)
    {
        if (item == null)
        {
            for (int i = 0; i < _size; i++)
                if (_items[i] == null)
                    return true;
            return false;
        }

        var c = EqualityComparer<T>.Default;
        for (int i = 0; i < _size; i++)
        {
            if (c.Equals(_items[i], item)) return true;
        }

        return false;
    }

    public int IndexOf(T value)
    {
        return Array.IndexOf((Array) _items, value, 0, _size);
    }

    public T[] ToArray()
    {
        var array = new T[_size];
        Array.Copy(_items, 0, array, 0, _size);
        return array;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < _size; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}