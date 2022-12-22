namespace Algorithms;

public static class ArrayHelper
{
    public static void Print<T>(string title, IReadOnlyList<T> array)
    {
        if(!string.IsNullOrEmpty(title))
            Console.Write(title + "\t");
        
        for (var i = 0; i < array.Count; i++)
        {
            if(i == array.Count - 1)
                Console.WriteLine(array[i]);
            else
            {
                Console.Write(array[i] + ", ");
            }
        }
    }
}