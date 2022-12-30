namespace DataStructures.AbstractDataTypes.Trees;

public class BinaryTree<T>
{
    private class Node
    {
        public Node? Left;
        public Node? Right;
        public T Data;

        public Node(T data)
        {
            Data = data;
        }
    }

    private Node? _root;

    public bool Add(T data)
    {
        Node? prev = null, next = _root;
        var comparer = Comparer<T>.Default;
        while (next is not null)
        {
            prev = next;
            var c = comparer.Compare(data, next.Data);
            switch (c)
            {
                case < 0:
                    next = next.Left;
                    break;
                case > 0:
                    next = next.Right;
                    break;
                default:
                    return false; //Exists!
            }
        }

        var newNode = new Node(data);
        if (_root is null)
        {
            _root = newNode;
        }
        else
        {
            var c = comparer.Compare(data, prev!.Data);
            if (c < 0)
                prev.Left = newNode;
            else
            {
                prev.Right = newNode;
            }
        }

        return true;
    }

    public void Remove(T data)
    {
        _root = Remove(_root, data);
    }

    private Node? Remove(Node? parent, T data)
    {
        if (parent is null)
            return null;

        var comparer = Comparer<T>.Default;
        var c = comparer.Compare(data, parent.Data);

        switch (c)
        {
            case < 0:
                parent.Left = Remove(parent.Left, data);
                break;
            case > 0:
                parent.Right = Remove(parent.Right, data);
                break;
            //Node to Delete!
            default:
            {
                // node with only one child or no child  
                if (parent.Left is null)
                    return parent.Right;
                if (parent.Right is null)
                    return parent.Left;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = Min(parent.Right);

                // Delete the inorder successor  
                parent.Right = Remove(parent.Right, parent.Data);
                break;
            }
        }

        return parent;
    }

    private static T Min(Node node)
    {
        var min = node.Data;

        while (node.Left != null)
        {
            min = node.Left.Data;
            node = node.Left;
        }

        return min;
    }

    public int GetDepth()
    {
        return GetDepth(_root);
    }

    private static int GetDepth(Node? parent)
    {
        return parent == null ? 0 : Math.Max(GetDepth(parent.Left), GetDepth(parent.Right)) + 1;
    }

    /// <summary>
    /// DLR
    /// </summary>
    public void TraversePreOrder()
    {
        Console.Write($"TraversePreOrder(DLR) with Depth {GetDepth()}: ");
        TraversePreOrder(_root);
        Console.WriteLine();
    }

    private static void TraversePreOrder(Node? parent)
    {
        if (parent is null) 
            return;
        
        Console.Write(parent.Data + " ");
        TraversePreOrder(parent.Left);
        TraversePreOrder(parent.Right);
    }

    /// <summary>
    /// LDR
    /// </summary>
    public void TraverseInOrder()
    {
         Console.Write($"TraverseInOrder(LDR) with Depth {GetDepth()}: ");
        TraverseInOrder(_root);
        Console.WriteLine();
    }
    
    private static void TraverseInOrder(Node? parent)
    {
        if (parent == null) 
            return;
        
        TraverseInOrder(parent.Left);
        Console.Write(parent.Data + " ");
        TraverseInOrder(parent.Right);
    }

    /// <summary>
    /// LRD
    /// </summary>
    public void TraversePostOrder()
    {
        Console.Write($"TraversePostOrder(LRD) with Depth {GetDepth()}: ");
        TraversePostOrder(_root);
        Console.WriteLine();
    }
    
    private static void TraversePostOrder(Node? parent)
    {
        if (parent is null) 
            return;
        
        TraversePostOrder(parent.Left);
        TraversePostOrder(parent.Right);
        Console.Write(parent.Data + " ");
    }
}