namespace DataStructures.AbstractDataTypes.Arrays;

public static class SimpleArray
{
    private static void Print<T>(string title, T[] array)
    {
        Console.WriteLine(title);
        for (var i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    public static void WaysToCreateAnArray()
    {
        string[] simpleInit = new string[4];

        string[] withSizeAndItems = new string[4] { "Item1", "Item2", "Item3", "Item4" };

        string[] withItemsAndTypeWithoutSize = new string[] { "Item1", "Item2", "Item3", "Item4" };

        string[] withOnlyItemsWithoutType = { "Volvo", "BMW", "Ford", "Mazda" };
    }

    public static void Sort(int[] array)
    {
        Print("Before sort", array);
        Array.Sort(array);
        Print("After sort", array);
    }

    public static void TwoDimensionalArrays()
    {
        int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 } };
    }
}