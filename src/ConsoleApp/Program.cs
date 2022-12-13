using DataStructures.AbstractDataTypes.Arrays;
using DataStructures.AbstractDataTypes.Lists;
using DataStructures.AbstractDataTypes.Stacks;

//ArrayUsage();
//ArrayListUsage();
//ListUsage();
//SinglyLinkedListUsage();
//DoublyLinkedListUsage();
StackUsage();

void ArrayUsage()
{
    SimpleArray.Sort(new[] {7, 5, 3, 9});  
}

void ArrayListUsage()
{
    var arrayList = new NikArrayList();
    arrayList.Add("Item 1");
    arrayList.Add(2);
    var exists = arrayList.Contains(2);    
    Console.WriteLine($"Element 2 Exists: {exists}");
}

void ListUsage()
{
    var list = new NikList<int>
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

void SinglyLinkedListUsage()
{
    var ll = new NikSinglyLinkedList<int>();
    ll.AddLast(5);
    ll.AddLast(2);
    ll.AddLast(3);

    foreach (var i in ll)
    {
        Console.WriteLine(i);
    }

    var last = ll[2];
    ll.Remove(1);
}

void DoublyLinkedListUsage()
{
    var ll = new NikDoublyLinkedList<int>();
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

void StackUsage()
{
    var stack = new NikStack<int>();
    stack.Push(1);
    stack.Push(2);
    stack.Push(3);
    stack.Push(4);

    var last = stack.Peek();
    var e1 = stack.Pop();
    var e2 = stack.Pop();
    var e3 = stack.Pop();
    var e4 = stack.Pop();
}