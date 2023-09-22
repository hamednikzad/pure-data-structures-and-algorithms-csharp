namespace DataStructures.AbstractDataTypes.Trees;

public class BinarySearchTree<T> where T : struct
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
        var newNode = new Node(data);
        if (_root is null)
        {
            _root = newNode;
            return true;
        }

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

        var c2 = comparer.Compare(data, prev!.Data);
        if (c2 < 0)
            prev.Left = newNode;
        else
        {
            prev.Right = newNode;
        }

        return true;
    }

    public void Remove(T data)
    {
        _root = Remove(_root, data);
    }

    private static Node? Remove(Node? parent, T data)
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

    public T? Min()
    {
        return _root is null ? null : Min(_root);
    }

    public T? Max()
    {
        return _root is null ? null : Max(_root);
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

    private static T Max(Node node)
    {
        var max = node.Data;

        while (node.Right != null)
        {
            max = node.Right.Data;
            node = node.Right;
        }

        return max;
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
        while (true)
        {
            if (parent == null) return;

            TraverseInOrder(parent.Left);
            Console.Write(parent.Data + " ");
            parent = parent.Right;
        }
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

    /// <summary>
    /// Level Order
    /// </summary>
    public void TraverseLevelOrder()
    {
        Console.Write($"TraverseLevelOrder(LRD) with Depth {GetDepth()}: ");
        TraverseLevelOrder(_root);
        Console.WriteLine();
    }

    private static void TraverseLevelOrder(Node? parent)
    {
        if (parent is null)
            return;

        var q = new Queue<Node>();
        q.Enqueue(parent);
        while (q.Count > 0)
        {
            var r = q.Dequeue();
            Console.Write(r.Data + " ");
            
            if (r.Left is not null)
                q.Enqueue(r.Left);
            if (r.Right is not null)
                q.Enqueue(r.Right);
        }
    }
}