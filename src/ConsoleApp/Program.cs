﻿using DataStructures.AbstractDataTypes.Arrays;
using DataStructures.AbstractDataTypes.Lists;

//ArrayUsage();
//ArrayListUsage();
//ListUsage();
LinkedListUsage();


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

void LinkedListUsage()
{
    var ll = new NikSinglyLinkedList<int>();
    ll.AddLast(5);
    ll.AddLast(2);
    ll.AddLast(3);

    foreach (var i in ll)
    {
        Console.WriteLine(i);
    }

    ll.Remove(3);
} 