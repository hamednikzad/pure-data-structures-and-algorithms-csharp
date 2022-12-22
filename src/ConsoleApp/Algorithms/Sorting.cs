using Algorithms.Sorting;

namespace ConsoleApp.Algorithms;

public static class Sorting
{
    #region BubbleSort

    private static void BubbleSort()
    {
        var array = new[] { 6, 3, 5, 2 };

        global::Algorithms.Sorting.BubbleSort.Sort(array, true);
    }

    private static void ImprovedBubbleSort()
    {
        var array = new[] { 2,5,3,6};

        global::Algorithms.Sorting.BubbleSort.ImprovedSort(array, true);
    }

    private static void BubbleSortUse()
    {
        Console.WriteLine("Sort:");
        BubbleSort();
        Console.WriteLine("---------------------------------");
        
        Console.WriteLine("ImprovedSort:");
        ImprovedBubbleSort();
    }

    #endregion

    #region Selection Sort

    private static void SelectionSortUse()
    {
        var array = new[] { 6, 3, 5, 2 };

        SelectionSort.Sort(array, true);
    }

    #endregion
    
    public static void Use()
    {
        //BubbleSortUse();
        SelectionSortUse();
    }
}