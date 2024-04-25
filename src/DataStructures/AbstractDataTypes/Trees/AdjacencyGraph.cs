namespace DataStructures.AbstractDataTypes.Trees;

public abstract class AdjacencyGraph
{
    public abstract void AddEdge(int v1, int v2);
    public abstract IEnumerable<int> GetAdjacentVertices(int vertex);
    public abstract void Print();
    public abstract void Dfs(int vertex);
    public abstract void Bfs(int vertex);
}