using DataStructures.AbstractDataTypes.Trees;

namespace ConsoleApp.Ds;

public static class Graphs
{
    private static void ActionsOnGraph(AdjacencyGraph graph)
    {
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(0, 3);
        graph.AddEdge(1, 3);
        
        graph.Print();
        
        const int v = 3;
        var adjacentVertices = graph.GetAdjacentVertices(v);
        Console.WriteLine($"Adjacent vertices of {v}: {string.Join(",", adjacentVertices)}");
        
        graph.Dfs(0);
        
        graph.Bfs(0);
    }
    
    private static void AdjacencyMatrixGraphUsage()
    {
        Console.WriteLine("AdjacencyMatrixGraph");
        
        var graph = new AdjacencyMatrixGraph(4, false);
        
        ActionsOnGraph(graph);
    }
    
    private static void AdjacencyListGraphUsage()
    {
        Console.WriteLine("AdjacencyListGraph");

        var graph = new AdjacencyListGraph(4, false);
        
        ActionsOnGraph(graph);
    }
    
    public static void Use()
    {
        AdjacencyMatrixGraphUsage();
        Console.WriteLine("----------------------");
        AdjacencyListGraphUsage();
    }
}