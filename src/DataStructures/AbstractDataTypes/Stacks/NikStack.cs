namespace DataStructures.AbstractDataTypes.Stacks;

public class NikStack<T>
{
    private T[] _items;
    private int _top = -1;
    private int _capacity;
    private readonly T[] _emptyArray = Array.Empty<T>();

    public int Count => _top + 1;

    public int Capacity => _capacity;
    public bool IsEmpty => _top == -1;
    
    public NikStack()
    {
        _items = _emptyArray;
        _capacity = 0;
    }

    public NikStack(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Should be non negative");

        _items = capacity == 0 ? _emptyArray : new T[capacity];

        _capacity = capacity;
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
        if (newCapacity < Count)
            throw new ArgumentOutOfRangeException(nameof(newCapacity), "Out of range");

        if (newCapacity == _capacity)
            return;

        if (newCapacity > 0)
        {
            var newItems = new T[newCapacity];

            if (Count > 0)
            {
                Array.Copy(_items, 0, newItems, 0, Count);
            }

            _items = newItems;
        }
        else
        {
            _items = _emptyArray;
        }

        _capacity = newCapacity;
    }

    public void Push(T value)
    {
        if (Count == _items.Length) CheckCapacity(Count + 1);

        _items[++_top] = value;
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new IndexOutOfRangeException("The Stack is empty");

        return _items[_top--];
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new IndexOutOfRangeException("The Stack is empty");

        return _items[_top];
    }
}