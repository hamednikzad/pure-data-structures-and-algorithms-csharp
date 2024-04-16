using System.Collections;
using DataStructures.AbstractDataTypes.Lists;

namespace DataStructures.AbstractDataTypes.Queues;

public class CircularQueue<T> : IEnumerable<T>
{
    public class Node
    {
        public Node(T value)
        {
            Value = value;
            Next = null;
        }

        public Node? Next { get; set; }
        public T Value { get; }
    }

    private Node? Front { get; set; }
    private Node? Rear { get; set; }

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;


    public void Enqueue(T value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        var newNode = new Node(value);
        if (Front is null)
        {
            Front = newNode;    
        }
        else
        {
            if (Rear != null) Rear.Next = newNode;
        }

        Rear = newNode;
        Rear.Next = Front;
        Count++;
    }

    public T? Dequeue()
    {
        if (Front is null || Rear is null)
            return default(T);

        T value;
        if (Front == Rear)
        {
            value = Front.Value;
            Front = null;
            Rear = null;
        }
        else
        {
            var t = Front;
            value = t.Value;
            Front = Front.Next;
            
            if (Rear is not null)
                Rear.Next = Front;
        }

        Count--;
        return value;
    }

    public T? Peek()
    {
        if (IsEmpty || Front is null)
            return default(T);

        var frontValue = Front.Value;
        var value = (T)frontValue!;
        
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (Front is null)
            yield break;

        var current = Front;
        while (current is not null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}