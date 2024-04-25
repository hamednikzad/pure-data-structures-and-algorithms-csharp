namespace DataStructures.AbstractDataTypes.Trees;

public class AdjacencyListGraph : AdjacencyGraph
{
    private readonly int _verticesNumbers;
    private readonly HashSet<int>[] _vertices;
    private readonly bool _isDirected;
    
    public AdjacencyListGraph(int verticesNumbers, bool isDirected)
    {
        _verticesNumbers = verticesNumbers;
        _vertices = new HashSet<int>[_verticesNumbers];

        for (var i = 0; i < _vertices.Length; i++)
        {
            _vertices[i] = new HashSet<int>();
        }
        
        _isDirected = isDirected;
    }
    
    public override void AddEdge(int v1, int v2)
    {
        if (v1 >= _verticesNumbers || v1 < 0 || v2 >= _verticesNumbers || v2 < 0)
            throw new ArgumentOutOfRangeException();

        _vertices[v1].Add(v2);
        
        if(!_isDirected)
            _vertices[v2].Add(v1);
    }
    
    public override IEnumerable<int> GetAdjacentVertices(int vertex)
    {
        if (vertex >= _verticesNumbers || vertex < 0)
            throw new ArgumentOutOfRangeException();
        
        return _vertices[vertex];
    }
    
    public override void Print()
    {
        var type = _isDirected ? "Directed" : "Undirected";
        Console.WriteLine($"{type} Graph Vertices: {_verticesNumbers}");
        
        for (var i = 0; i < _vertices.GetLength(0); i++)
        {
            Console.Write($"V{i} => ");
            foreach (var item in _vertices[i])
            {
                Console.Write(item + ", ");
            }
            
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Depth First Search
    /// </summary>
    public override void Dfs(int vertex)
    {
        Console.Write($"DFS of {vertex}: ");
        
        var visited = new bool[_verticesNumbers];
        
        Dfs(vertex, visited);
        
        Console.WriteLine();
    }

    private void Dfs(int vertex, bool[] visited)
    {
        visited[vertex] = true;
        Console.Write(vertex + " ");

        foreach (var v in _vertices[vertex])
        {
            if(!visited[v])
                Dfs(v, visited);
        }
    }

    /// <summary>
    /// Breadth  First Search
    /// </summary>
    public override void Bfs(int vertex)
    {
        Console.Write($"BFS of {vertex}: ");
        
        var visited = new bool[_verticesNumbers];
        var queue = new Queues.LinkedListQueue<int>();

        visited[vertex] = true;
        queue.Enqueue(vertex);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.Write(current + " ");

            foreach (var v in _vertices[current])
            {
                if (!visited[v])
                {
                    visited[v] = true;
                    queue.Enqueue(v);
                }
            }
        }
        
        Console.WriteLine();
    }
}