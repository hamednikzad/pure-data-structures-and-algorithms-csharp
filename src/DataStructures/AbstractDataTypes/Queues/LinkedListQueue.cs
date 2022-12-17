using System.Collections;
using DataStructures.AbstractDataTypes.Lists;

namespace DataStructures.AbstractDataTypes.Queues;

public class LinkedListQueue<T> : IEnumerable<T>
{
    private readonly SinglyLinkedList<T> _list;

    public LinkedListQueue()
    {
        _list = new SinglyLinkedList<T>();
    }

    public bool IsEmpty => _list.IsEmpty;
    public int Count => _list.Count;

    public void Enqueue(T value)
    {
        _list.AddLast(value);
    }

    public T Dequeue()
    {
        if (IsEmpty)
            throw new IndexOutOfRangeException("The Queue is empty");

        var value = _list.Head!.Value;
        _list.RemoveFirst();
        
        return value;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new IndexOutOfRangeException("The Queue is empty");
        
        return _list.Head!.Value;
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