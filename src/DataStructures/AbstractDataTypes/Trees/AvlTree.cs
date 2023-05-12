namespace DataStructures.AbstractDataTypes.Trees;

public class AvlTree<T> where T : struct
{
    public class Node
    {
        public Node? Left, Right;
        public T Data;
        public int Height;

        public Node(T data)
        {
            Data = data;
            Height = 1;
        }
    }

    private Node? _root;

    private static int GetHeight(Node? node)
    {
        return node?.Height ?? 0;
    }

    private static Node RightRotate(Node y)
    {
        var x = y.Left;
        var t2 = x.Right;
        x.Right = y;
        y.Left = t2;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        return x;
    }

    private static Node LeftRotate(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;
        y.Left = x;
        x.Right = T2;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        return y;
    }

    private static int GetBalance(Node? node)
    {
        if (node == null)
            return 0;
        
        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    public Node Insert(Node node, T key)
    {
        var comparer = Comparer<T>.Default;
        if (node == null)
            return (new Node(key));

        var c = comparer.Compare(key, node.Data);
        switch (c)
        {
            case < 0:
                node.Left = Insert(node.Left, key);
                break;
            case > 0:
                node.Right = Insert(node.Right, key);
                break;
            default:
                return node; //Exists!
        }

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        int balance = GetBalance(node);
        if (balance > 1 && comparer.Compare(key, node.Left.Data) < 0)
            return RightRotate(node);
        if (balance < -1 && comparer.Compare(key, node.Right.Data) > 0)
            return LeftRotate(node);
        if (balance > 1 && comparer.Compare(key, node.Left.Data) > 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (balance < -1 && comparer.Compare(key, node.Right.Data) < 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    public void PrintTree(Node root)
    {
        if (root == null)
            return;
        if (root != null)
        {
            PrintTree(root.Left);
            Console.Write(root.Data + " ");
            PrintTree(root.Left);
        }
    }
}