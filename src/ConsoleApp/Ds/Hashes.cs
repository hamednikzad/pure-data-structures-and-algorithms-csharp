using DataStructures.AbstractDataTypes.Hashes;

namespace ConsoleApp.Ds;

public static class Hashes
{
    private static void HashTableLinearProbingUsage()
    {
        var hashTable = new HashTableLinearProbing<int>(2);
        for (var i = 0; i < 50; i++)
        {
            hashTable.Add(i);
        }
        Console.WriteLine($"Table Count:{hashTable.Count}");
        foreach (var item in hashTable)
        {
            Console.WriteLine($"Item:{item}");
        }
        hashTable.Remove(2);
        hashTable.Contains(2);
        Console.WriteLine($"Table New Count:{hashTable.Count}");
    }

    private static void HashTableSeparateChainingUsage()
    {
        var hashTable = new HashTableSeparateChaining<int>(4);
        for (var i = 0; i < 50; i++)
        {
            hashTable.Add(i);
        }
        Console.Write($"Table Count:{hashTable.Count}");
        foreach (var item in hashTable)
        {
            Console.WriteLine(item);
        }

        var exists = hashTable.Contains(4);
        Console.WriteLine(exists);
    }

    public static void Use()
    {
        HashTableLinearProbingUsage();
        HashTableSeparateChainingUsage();
    }
}