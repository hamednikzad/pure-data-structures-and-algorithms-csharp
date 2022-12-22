using Algorithms.Sorting;

namespace ConsoleApp.Algorithms;

public static class Sorting
{
    private static void Sort()
    {
        var array = new[] { 6, 3, 5, 2 };

        BubbleSort.Sort(array, true);
    }

    private static void ImprovedSort()
    {
        var array = new[] { 2,5,3,6};

        BubbleSort.ImprovedSort(array, true);
    }

    public static void Use()
    {
        Console.WriteLine("Sort:");
        Sort();
        Console.WriteLine("---------------------------------");
        
        Console.WriteLine("ImprovedSort:");
        ImprovedSort();
    }
}