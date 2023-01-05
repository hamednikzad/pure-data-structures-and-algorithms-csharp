using Algorithms;
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
        Console.WriteLine("Bubble Sort:");
        BubbleSort();
        Console.WriteLine("---------------------------------");
        
        Console.WriteLine("Improved Bubble Sort:");
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

    #region Insertion Sort

    private static void InsertionSortUse()
    {
        var array = new[] { 6, 3, 5, 2 };

        InsertionSort.Sort(array, true);
    }

    #endregion

    #region Shell Sort

    private static void ShellSortUse()
    {
        var array = new[] { 6, 3, 5, 2 };
        
        Console.WriteLine("Shell Sort:");
        ArrayHelper.Print("Original:\t", array);
        ShellSort.Sort(array, true);
    }

    #endregion
    
    public static void Use()
    {
        // BubbleSortUse();
        // SelectionSortUse();
        // InsertionSortUse();
        ShellSortUse();
    }
}