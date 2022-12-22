using DataStructures.AbstractDataTypes.Lists;

namespace ConsoleApp.Ds;

public static class Lists
{
    private static void ArrayListUsage()
    {
        var arrayList = new ArrayList
        {
            "Item 1",
            2
        };
        var exists = arrayList.Contains(2);
        Console.WriteLine($"Element 2 Exists: {exists}");
    }
    
    private static void ListUsage()
    {
        var list = new DataStructures.AbstractDataTypes.Lists.List<int>
        {
            1,
            2,
            3,
            4
        };

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    private static void SinglyLinkedListUsage()
    {
        var ll = new SinglyLinkedList<int>();
        ll.AddLast(5);
        ll.AddLast(2);
        ll.AddLast(3);

        foreach (var i in ll)
        {
            Console.WriteLine(i);
        }

        var last = ll[2];
        Console.WriteLine(last);
        ll.Remove(1);
        Console.WriteLine($"Count:{ll.Count}");
    }

    private static void DoublyLinkedListUsage()
    {
        var ll = new DoublyLinkedList<int>();
        ll.AddLast(5);
        ll.AddLast(2);
        ll.AddLast(3);

        foreach (var i in ll)
        {
            Console.WriteLine(i);
        }

        ll.Insert(3, 1);
        ll.Remove(3);
    }

    public static void Use()
    {
        ArrayListUsage();
        ListUsage();
        SinglyLinkedListUsage();
        DoublyLinkedListUsage();
    }
}