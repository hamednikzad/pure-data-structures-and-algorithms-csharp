namespace Algorithms.Sorting;

public static class SelectionSort
{
    public static void Sort<T>(T[] array, bool print = false)
        where T : IComparable
    {
        if (print) ArrayHelper.Print($"Original:", array);

        for (var i = 0; i < array.Length - 1; i++)
        {
            var min = i;
            for (var j = i + 1; j < array.Length; j++)
            {
                if (array[j].CompareTo(array[min]) < 0)
                {
                    min = j;
                }
            }

            if (min != i)
                (array[i], array[min]) = (array[min], array[i]);
            
            if (print) ArrayHelper.Print($"Step {i}:", array);

        }
    }
}