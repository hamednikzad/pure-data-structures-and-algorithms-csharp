using Algorithms.Encoding;

namespace ConsoleApp.Algorithms;

public static class Encoding
{
    private static void Rle()
    {
        const string testCode = "aaaaaaaaaaaaaaaaaaaaaasdadddfdf fdf";
        var code = RleEncoder.Encode(testCode);
        var decode = RleEncoder.Decode(code);
        
        Console.WriteLine("Run-length encoding");
        Console.WriteLine($"Original: {testCode}");
        Console.WriteLine($"Encoded:  {code}");
        Console.WriteLine($"Decoded:  {decode}");
    }
    
    public static void Use()
    {
        Rle();
    }
}