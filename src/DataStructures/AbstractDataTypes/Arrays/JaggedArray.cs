namespace DataStructures.AbstractDataTypes.Arrays;

public static class JaggedArray
{
    public static void WaysToCreateAJaggedArray()
    {
        var jArray = new int[3][];
        jArray[0] = new int[2];
        jArray[1] = new int[5];
        jArray[2] = new int[9];

        jArray[1][2] = 6;

        var jArray2 = new int[2][];
        jArray2[0] = new[] { 1, 2, 3 };
        jArray2[1] = new[] { 4, 5, 6, 7, 8 };
    }
}