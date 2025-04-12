using dm_project.DataStructures;

namespace dm_project;

public static class DFS 
{
    //Working with adjacency
    public static HashSet<Vertex> DFS_Search(Vertex start)
    {
        var visited = new HashSet<Vertex>();
        DFS_Search(start, visited);
        return visited;
    }

    private static HashSet<Vertex> DFS_Search(Vertex start, HashSet<Vertex> visited)
    {
        visited.Add(start);
        foreach (var neighbor in start.AdjacentVertices)
        {
            if (!visited.Contains(neighbor))
            {
                DFS_Search(neighbor, visited);
            }
        }
        return visited;
    }
    //
    
    //Working with Matrix
    public static HashSet<int> GetConnectivityComponentFromMatrix(int[,] adjacencyMatrix, int startVertexIndex)
    {
        int n = adjacencyMatrix.GetLength(0);
        var visited = new HashSet<int>();
        DFS_Matrix(startVertexIndex, adjacencyMatrix, visited);
        return visited;
    }

    private static void DFS_Matrix(int vertexIndex, int[,] adjacencyMatrix, HashSet<int> visited)
    {
        visited.Add(vertexIndex);

        for (int i = 0; i < adjacencyMatrix.GetLength(1); i++)
        {
            if (adjacencyMatrix[vertexIndex, i] == 1 && !visited.Contains(i))
            {
                DFS_Matrix(i, adjacencyMatrix, visited);
            }
        }
    }
    //

}