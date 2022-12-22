namespace Algorithms.Sorting;

public static class BubbleSort
{
    private static void Swap<T>(ref T left, ref T right)
    {
        (left, right) = (right, left);
    }

    public static void Sort<T>(T[] array, bool print = false)
        where T : IComparable
    {
        if (print) ArrayHelper.Print($"Original:", array);

        for (var i = array.Length - 1; i >= 0; i--)
        {
            for (var j = 0; j <= i - 1; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                    Swap(ref array[j], ref array[j + 1]);
            }

            if (print) ArrayHelper.Print($"Step {i}", array);
        }
    }

    public static void ImprovedSort<T>(T[] array, bool print = false)
        where T : IComparable
    {
        if (print) ArrayHelper.Print($"Original:", array);

        var swapped = true;
        for (var i = array.Length - 1; i >= 0 && swapped; i--)
        {
            swapped = false;
            for (var j = 0; j <= i - 1; j++)
            {
                if (array[j].CompareTo(array[j + 1]) <= 0) continue;

                Swap(ref array[j], ref array[j + 1]);
                swapped = true;
            }

            if (print) ArrayHelper.Print($"Step {i}, Swapped: {swapped}", array);
        }
    }
}