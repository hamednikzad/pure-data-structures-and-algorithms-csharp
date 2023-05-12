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
        var tree = new AvlTree<int>();

        tree.Root = tree.Insert(tree.Root, 10); 
        tree.Root = tree.Insert(tree.Root, 11); 
        tree.Root = tree.Insert(tree.Root, 12); 
        tree.Root = tree.Insert(tree.Root, 13); 
        tree.Root = tree.Insert(tree.Root, 14); 
        tree.Root = tree.Insert(tree.Root, 15); 
        Console.WriteLine("AVL Tree: ");
        tree.PrintTree(tree.Root);
    }

    public static void Use()
    {
        //BinaryTreeUsage();
        AvlTreeUsage();
    }

}