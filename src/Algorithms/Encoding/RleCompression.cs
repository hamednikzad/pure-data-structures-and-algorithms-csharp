using System.Text;

namespace Algorithms.Encoding;

/// <summary>
/// Run-length encoding (RLE) is a form of lossless data compression in which runs of data (sequences in which the same data value occurs in many consecutive data elements)
/// are stored as a single data value and count, rather than as the original run.
/// </summary>
public static class RleEncoder
{
    public static string Encode(string input)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < input.Length; i++)
        {
            var count = 1;
            while (i < input.Length - 1 && input[i] == input[i + 1])
            {
                count++;
                i++;
            }

            sb.Append(input[i] + count.ToString());
        }

        return sb.ToString();
    }

    private static (int number, int ii) GetNumber(string input, int index)
    {
        int i;
        for (i = index; i < input.Length; i++)
        {
            if (!char.IsDigit(input[i]))
            {
                break;
            }
        }

        return index == i ? (0, 0) : (int.Parse(input.Substring(index, i - index)), i);
    }

    public static string Decode(string input)
    {
        var result = "";
        for (var i = 0; i < input.Length;)
        {
            if (!char.IsDigit(input[i]))
            {
                var (num, index) = GetNumber(input, i + 1);
                result += new string(input[i], num);
                i = index;
            }
            else
            {
                i++;
            }
        }

        return result;
    }
}