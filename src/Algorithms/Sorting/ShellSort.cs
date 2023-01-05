namespace Algorithms.Sorting;

/// <summary>
/// Also called Diminishing Increment Sort
/// Also known as n-gap Insertion Sort
/// </summary>
public static class ShellSort
{
    public static void Sort<T>(T[] array, bool print = false)
        where T : IComparable
    {
        var size = array.Length;
        for (var interval = size / 2; interval > 0; interval /= 2)
        {
            for (var i = interval; i < size; i++)
            {
                var currentKey = array[i];
                var k = i;
                while (k >= interval && array[k - interval].CompareTo(currentKey) > 0)
                {
                    array[k] = array[k - interval];
                    k -= interval;
                }
                array[k] = currentKey;
            }
            if (print) ArrayHelper.Print($"interval {interval}:\t", array);
        }
    }
}