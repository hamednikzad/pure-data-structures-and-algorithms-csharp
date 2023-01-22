using System.Collections;
using DataStructures.AbstractDataTypes.Lists;

namespace DataStructures.AbstractDataTypes.Stacks;

public class LinkedListStack<T> : IEnumerable<T>
{
    private readonly SinglyLinkedList<T> _list;

    public LinkedListStack()
    {
        _list = new SinglyLinkedList<T>();
    }

    public bool IsEmpty => _list.IsEmpty;
    public int Count => _list.Count;
    
    public void Push(T value)
    {
        _list.AddFirst(value);
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new IndexOutOfRangeException("The Stack is empty");

        var value = _list.Remove(0);
        return value!;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new IndexOutOfRangeException("The Stack is empty");
        
        var headValue = _list.GetHead();
        var value = ((T)headValue!);
        
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}