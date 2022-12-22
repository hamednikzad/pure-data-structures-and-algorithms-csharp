using DataStructures.AbstractDataTypes.Stacks;

namespace ConsoleApp.Ds;

public static class Stacks
{
    private static void StackUsage()
    {
        var stack = new DataStructures.AbstractDataTypes.Stacks.Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        var last = stack.Peek();
        var e1 = stack.Pop();
        var e2 = stack.Pop();
        var e3 = stack.Pop();
        var e4 = stack.Pop();
        
        Console.WriteLine(last);
        Console.WriteLine(e1);
        Console.WriteLine(e2);
        Console.WriteLine(e3);
        Console.WriteLine(e4);
    }

    private static void LinkedListStackUsage()
    {
        var stack = new LinkedListStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        var last = stack.Peek();
        var e1 = stack.Pop();
        var e2 = stack.Pop();
        var e3 = stack.Pop();
        var e4 = stack.Pop();
        
        Console.WriteLine(last);
        Console.WriteLine(e1);
        Console.WriteLine(e2);
        Console.WriteLine(e3);
        Console.WriteLine(e4);
    }

    public static void Use()
    {
        StackUsage();
        LinkedListStackUsage();
    }
}