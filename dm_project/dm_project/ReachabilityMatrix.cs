using dm_project.DataStructures;

namespace dm_project;

public class ReachabilityMatrix
{
    public int[,] BFS_Build(Graph graph)
    {
        int[,] reachabilityMatrix = new int[graph.Vertices.Count, graph.Vertices.Count];
        var vertices = graph.Vertices;
        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            var currentVertex = vertices[i];
            for (int j = 1; j < graph.Vertices.Count; j++)
            {
                var vertexToCheck = graph.Vertices[j];
                if (currentVertex.Equals(vertexToCheck))
                {
                    reachabilityMatrix[i, j] = 0;
                }
                else
                {
                    var (way, isReachable) = BFS.Breadth_First_Search(currentVertex, vertexToCheck);
                    if (isReachable)
                    {
                        reachabilityMatrix[i, j] = 1;
                    }
                    else
                    {
                        reachabilityMatrix[i, j] = 0;
                    }
                }
            }
        }

        PrintReachabilityMatrix(reachabilityMatrix, graph);
        return reachabilityMatrix;
    }

    public int[,] DFS_Build(Graph graph)
    {
        var vertices = graph.Vertices;
        var reachedVertices = new HashSet<Vertex>();
        int[,] reachabilityMatrix = new int[graph.Vertices.Count, graph.Vertices.Count];
        
        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            if (!reachedVertices.Contains(vertices[i]))
            {
                reachedVertices.Add(vertices[i]);
                var connectivityComponent = new HashSet<Vertex>();//Do DFS Here, which returns a connectivity component for a particular point
                for (int j = 0; j < graph.Vertices.Count; j++)
                {
                    if (connectivityComponent.Contains(vertices[j]))
                    {
                        reachabilityMatrix[i, j] = 1;
                    }
                    else
                    {
                        reachabilityMatrix[i, j] = 0;
                    }
                }
            }
        }
        PrintReachabilityMatrix(reachabilityMatrix, graph);
        return reachabilityMatrix;
    }

    public void PrintReachabilityMatrix(int[,] reachabilityMatrix, Graph graph)
    {
        var vertices  = graph.Vertices;
        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            Console.Write(vertices[i].Name);
        }
        
        for (int i = 0; i < reachabilityMatrix.GetLength(0); i++)
        {
            Console.Write($"{vertices[i].Name}  ");
            for (int j = 0; j < reachabilityMatrix.GetLength(1); j++)
            {
                Console.Write($"{reachabilityMatrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}