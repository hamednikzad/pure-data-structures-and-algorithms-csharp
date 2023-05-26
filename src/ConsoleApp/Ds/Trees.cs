using System.Diagnostics;
using DataStructures.AbstractDataTypes.Trees;

namespace ConsoleApp.Ds;

public static class Trees
{
    private static void BinaryTreeUsage()
    {
        var bTree = new BinarySearchTree<int>();
        Console.WriteLine($"Min:{bTree.Min()}, Max:{bTree.Max()}");
        bTree.Add(10);
        bTree.Add(5);
        bTree.Add(15);
        bTree.Add(13);
        bTree.Add(12);
        bTree.Add(14);
        bTree.Add(13);
        Console.WriteLine($"Depth: {bTree.GetDepth()}");
        
        bTree.TraversePreOrder();
        bTree.TraverseInOrder();
        bTree.TraversePostOrder();
        
        bTree.Remove(13);

        var min = bTree.Min();
        var max = bTree.Max();
        
        Console.WriteLine($"Min:{min}, Max:{max}");
        bTree.TraversePreOrder();
    }

    private static void AvlTreeUsage()
    {
        var avlTree = new AvlTree<int>();
        avlTree.Add(5);
        avlTree.Add(3);
        avlTree.Add(7);
        avlTree.Add(2);
        avlTree.Add(4);
        avlTree.Add(13);
        avlTree.Add(17);
        avlTree.TraversePreOrder();
        avlTree.TraverseInOrder();
        avlTree.TraversePostOrder();
        Console.WriteLine($"Is 13 Exists: {avlTree.IsExist(13)}");
        Console.WriteLine("Deleting 7...");
        avlTree.Delete(7);
        avlTree.TraverseInOrder();
        Console.WriteLine($"Is 7 Exists: {avlTree.IsExist(7)}");
    }

    public static void Use()
    {
        //BinaryTreeUsage();
        AvlTreeUsage();
    }

}