namespace DataStructures.AbstractDataTypes.Trees;

public class AdjacencyMatrixGraph : AdjacencyGraph
{
    private readonly int _verticesNumbers;
    private readonly int[,] _adjacency;
    private readonly bool _isDirected;
    
    public AdjacencyMatrixGraph(int verticesNumbers, bool isDirected)
    {
        _verticesNumbers = verticesNumbers;
        _adjacency = new int[_verticesNumbers, _verticesNumbers];
        _isDirected = isDirected;
    }

    public override void AddEdge(int v1, int v2)
    {
        if (v1 >= _verticesNumbers || v1 < 0 || v2 >= _verticesNumbers || v2 < 0)
            throw new ArgumentOutOfRangeException();

        _adjacency[v1, v2] = 1;
        
        if(!_isDirected)
            _adjacency[v2, v1] = 1;
    }

    public override IEnumerable<int> GetAdjacentVertices(int vertex)
    {
        if (vertex >= _verticesNumbers || vertex < 0)
            throw new ArgumentOutOfRangeException();

        var result = new List<int>();

        for (var i = 0; i < _verticesNumbers; i++)
        {
            if(_adjacency[vertex, i] > 0)
                result.Add(i);
        }

        return result;
    }
    
    public override void Print()
    {
        var type = _isDirected ? "Directed" : "Undirected";
        Console.WriteLine($"{type} Graph Vertices: {_verticesNumbers}");
        
        for (var i = 0; i < _adjacency.GetLength(0); i++)
        {
            Console.Write($"V{i} => ");
            
            for (var j = 0; j < _adjacency.GetLength(1); j++)
            {
                if (_adjacency[i, j] > 0)
                {
                    Console.Write(j + ", ");    
                }
                
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

        for (var i = 0; i < _verticesNumbers; i++)
        {
            if(!visited[i] && _adjacency[vertex, i] > 0)
                Dfs(i, visited);
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

            for (var i = 0; i < _verticesNumbers; i++)
            {
                if (!visited[i] && _adjacency[vertex, i] > 0)
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
        
        Console.WriteLine();
    }
}