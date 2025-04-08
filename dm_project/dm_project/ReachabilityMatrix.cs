namespace dm_project;

public class ReachabilityMatrix
{
    public int[,] BFS_Build(Graph graph)
    {
        int[,] reachabilityMatrix = new int[graph.Vertices.Count, graph.Vertices.Count];
        var vertex  = graph.Vertices;
        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            var currentVertex = vertex[i];
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
        return reachabilityMatrix;
    }

    public int[,] DFS_Build(Graph graph)
    {
        throw new NotImplementedException();
    }
    
    public void PrintReachabilityMatrix(int[,] reachabilityMatrix)
    {
        for (int i = 0; i < reachabilityMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < reachabilityMatrix.GetLength(1); j++)
            {
                Console.Write($"{reachabilityMatrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
    //ToDo: complete the print of matrix with the names of vertices, to make visualisation better
    //ToDo: complete build of matrix using DFS;
}