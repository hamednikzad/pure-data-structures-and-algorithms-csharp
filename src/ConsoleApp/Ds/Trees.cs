using DataStructures.AbstractDataTypes.Trees;

namespace ConsoleApp.Ds;

    public struct MyStruct
    {
        public int A;

        public MyStruct()
        {
            A = 3;
        }
    }
public static class Trees
{
    private static void BinaryTreeUsage()
    {
        var bTree = new BinaryTree<int>();
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
        
        bTree.TraversePreOrder();
    }

    public static void Use()
    {
        BinaryTreeUsage();
    }

}