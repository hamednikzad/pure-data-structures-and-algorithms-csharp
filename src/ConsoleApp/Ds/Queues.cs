using DataStructures.AbstractDataTypes.Queues;

namespace ConsoleApp.Ds;

public static class Queues
{
    private static void LinedListQueueUsage()
    {
        var queue = new LinkedListQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);

        var first = queue.Peek();
        var e1 = queue.Dequeue();
        var e2 = queue.Dequeue();
        var e3 = queue.Dequeue();
        var e4 = queue.Dequeue();
        
        Console.WriteLine(first);
        Console.WriteLine(e1);
        Console.WriteLine(e2);
        Console.WriteLine(e3);
        Console.WriteLine(e4);
    }

    public static void Use()
    {
        LinedListQueueUsage();
    }
}