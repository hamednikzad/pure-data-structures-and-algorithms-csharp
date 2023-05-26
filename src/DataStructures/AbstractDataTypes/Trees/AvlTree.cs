namespace DataStructures.AbstractDataTypes.Trees;

public class AvlTree<T> where T : struct
{
    public class Node
    {
        public Node? Left, Right;
        public T Data;

        public Node(T data)
        {
            Data = data;
        }
    }

    private Node? _root;

    public void Add(T data)
    {
        var newNode = new Node(data);
        if (_root is null)
        {
            _root = newNode;
            return;
        }

        _root = Insert(_root, newNode);
    }

    private static Node Insert(Node? current, Node newNode)
    {
        if (current is null)
        {
            current = newNode;
            return current;
        }

        var comparer = Comparer<T>.Default;
        var c = comparer.Compare(newNode.Data, current.Data);

        switch (c)
        {
            case < 0:
                current.Left = Insert(current.Left, newNode);
                current = GetBalancedTree(current);
                break;
            case > 0:
                current.Right = Insert(current.Right, newNode);
                current = GetBalancedTree(current);
                break;
            default:
                return current; //Exists!
        }

        return current;
    }

    public void Delete(T target)
    {
        _root = Delete(_root, target);
    }

    private static Node? Delete(Node? current, T target)
    {
        if (current is null)
        {
            return null;
        }

        var comparer = Comparer<T>.Default;
        var c = comparer.Compare(target, current.Data);

        switch (c)
        {
            case < 0:
                current.Left = Delete(current.Left, target);
                if (GetBalanceFactor(current) == -2) //here
                {
                    current = GetBalanceFactor(current.Right) <= 0 ? RotateRr(current) : RotateRl(current);
                }

                break;
            case > 0:
                current.Right = Delete(current.Right, target);
                if (GetBalanceFactor(current) == 2)
                {
                    current = GetBalanceFactor(current.Left) >= 0 ? RotateLl(current) : RotateLr(current);
                }

                break;
            default: //Found!
                if (current.Right != null)
                {
                    var parent = current.Right;
                    while (parent.Left != null)
                    {
                        parent = parent.Left;
                    }

                    current.Data = parent.Data;
                    current.Right = Delete(current.Right, parent.Data);
                    if (GetBalanceFactor(current) == 2)
                    {
                        current = GetBalanceFactor(current.Left) >= 0 ? RotateLl(current) : RotateLr(current);
                    }
                }
                else
                {
                    return current.Left;
                }

                break;
        }

        return current;
    }

    public bool IsExist(T key)
    {
        if (_root is null)
            return false;
        var node = Find(key, _root);
        if (node is null)
            return false;
        
        var comparer = Comparer<T>.Default;
        return comparer.Compare(node.Data, key) == 0;
    }

    private static Node? Find(T target, Node? current)
    {
        if (current is null)
            return null;
        
        var comparer = Comparer<T>.Default;
        var c = comparer.Compare(target, current.Data);
        return c switch
        {
            < 0 => Find(target, current.Left),
            > 0 => Find(target, current.Right),
            _ => current
        };
    }

    private static Node GetBalancedTree(Node current)
    {
        var bFactor = GetBalanceFactor(current);
        switch (bFactor)
        {
            case > 1 when GetBalanceFactor(current.Left) > 0:
                current = RotateLl(current);
                break;
            case > 1:
                current = RotateLr(current);
                break;
            case < -1 when GetBalanceFactor(current.Right) > 0:
                current = RotateRl(current);
                break;
            case < -1:
                current = RotateRr(current);
                break;
        }

        return current;
    }

    private static Node RotateRr(Node parent)
    {
        var pivot = parent.Right;
        parent.Right = pivot.Left;
        pivot.Left = parent;
        return pivot;
    }

    private static Node RotateLl(Node parent)
    {
        var pivot = parent.Left;
        parent.Left = pivot.Right;
        pivot.Right = parent;
        return pivot;
    }

    private static Node RotateLr(Node parent)
    {
        var pivot = parent.Left;
        parent.Left = RotateRr(pivot);
        return RotateLl(parent);
    }

    private static Node RotateRl(Node parent)
    {
        var pivot = parent.Right;
        parent.Right = RotateLl(pivot);
        return RotateRr(parent);
    }

    private static int GetBalanceFactor(Node? node)
    {
        if (node == null)
            return 0;

        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    private static int GetHeight(Node? current)
    {
        if (current == null)
            return 0;

        var left = GetHeight(current.Left);
        var right = GetHeight(current.Right);
        return Math.Max(left, right) + 1;
    }

    private int GetDepth()
    {
        return GetDepth(_root);
    }

    private static int GetDepth(Node? parent)
    {
        return parent == null ? 0 : Math.Max(GetDepth(parent.Left), GetDepth(parent.Right)) + 1;
    }

    public void TraversePreOrder()
    {
        Console.WriteLine($"TraversePreOrder(LDR) with Depth {GetDepth()}: ");
        TraversePreOrder(_root);
        Console.WriteLine();
    }
    
    public void TraverseInOrder()
    {
        Console.WriteLine($"TraverseInOrder(LDR) with Depth {GetDepth()}: ");
        TraverseInOrder(_root);
        Console.WriteLine();
    }
    
    public void TraversePostOrder()
    {
        Console.WriteLine($"TraversePostOrder(LDR) with Depth {GetDepth()}: ");
        TraversePostOrder(_root);
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

    private static void TraversePostOrder(Node? parent)
    {
        if (parent is null)
            return;

        TraversePostOrder(parent.Left);
        TraversePostOrder(parent.Right);
        Console.Write(parent.Data + " ");
    }
}