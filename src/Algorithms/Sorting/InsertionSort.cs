namespace Algorithms.Sorting;

public static class InsertionSort
{
    public static void Sort<T>(T[] array, bool print = false)
        where T : IComparable
    {
        if (print) ArrayHelper.Print($"Original:", array);

        for (var i = 1; i <= array.Length - 1; i++)
        {
            var temp = array[i];
            var j = i;
            
            while (j >= 1 && array[j -1].CompareTo(temp) > 0)
            {
                array[j] = array[j - 1];
                j--;
            }

            array[j] = temp;
            
            if (print) ArrayHelper.Print($"Step {i}:\t", array);
        }
    }
}