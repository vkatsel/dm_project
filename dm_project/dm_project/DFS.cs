using dm_project.DataStructures;

namespace dm_project;

public static class DFS 
{
    public static HashSet<Vertex> DFS_Search(Graph graph, Vertex start)
    {
        var visited = new HashSet<Vertex>();
        DFS_Search(graph, start, visited);
        return visited;
    }
    public static HashSet<Vertex> DFS_Search(Graph graph, Vertex start, HashSet<Vertex> visited)
    {
        visited.Add(start);
        foreach (var neighbor in start.AdjacentVertices)
        {
            if (!visited.Contains(neighbor))
            {
                DFS_Search(graph, neighbor, visited);
            }
        }
        return visited;
    }

}