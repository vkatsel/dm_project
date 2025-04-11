using dm_project.DataStructures;

namespace dm_project;

public static class ReachabilityMatrix
{
    public static int[,] BFS_Build(Graph graph)
    {
        int[,] reachabilityMatrix = new int[graph.Vertices.Count, graph.Vertices.Count];
        var vertices = graph.Vertices;
        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            var currentVertex = vertices[i];
            for (int j = 0; j < graph.Vertices.Count; j++)
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

    public static int[,] DFS_Build(Graph graph)
    {
        var vertices = graph.Vertices;
        var reachedVertices = new HashSet<Vertex>();
        int[,] reachabilityMatrix = new int[graph.Vertices.Count, graph.Vertices.Count];
        
        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            if (!reachedVertices.Contains(vertices[i]))
            {
                reachedVertices.Add(vertices[i]);
                var connectivityComponent = DFS.DFS_Search(graph, vertices[i]);
                
                foreach (var vertex in connectivityComponent)
                {
                    int index = vertices.IndexOf(vertex);
                    foreach (var otherVertex in connectivityComponent)
                    {
                        int otherIndex = vertices.IndexOf(otherVertex);
                        reachabilityMatrix[index, otherIndex] = 1;
                    }
                }
            }
        }

        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            for (int j = 0; j < graph.Vertices.Count; j++)
            {
                if (j==i)
                {
                    reachabilityMatrix[i, j] = 0;
                }
            }
        }
        PrintReachabilityMatrix(reachabilityMatrix, graph);
        return reachabilityMatrix;
    }
    
    public static int[,] BFS_Matrix_Build(Graph graph)
    {
        int n = graph.Vertices.Count;
        int[,] matrix = new int[n, n];
        int[,] adjMatrix = graph.BuildAdjacencyMatrix();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j)
                    matrix[i, j] = BFS_Matrix(adjMatrix, i, j) ? 1 : 0;
            }
        }

        return matrix;
    }

    public static int[,] DFS_Matrix_Build(Graph graph)
    {
        int n = graph.Vertices.Count;
        int[,] matrix = new int[n, n];
        int[,] adjMatrix = graph.BuildAdjacencyMatrix();

        for (int i = 0; i < n; i++)
        {
            var visited = DFS_FromNode(adjMatrix, i);
            for (int j = 0; j < n; j++)
            {
                if (i != j && visited[j])
                    matrix[i, j] = 1;
            }
        }

        return matrix;
    }

    private static bool BFS_Matrix(int[,] matrix, int start, int target)
    {
        int n = matrix.GetLength(0);
        var visited = new bool[n];
        var queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            if (current == target)
                return true;

            for (int i = 0; i < n; i++)
            {
                if (matrix[current, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }

        return false;
    }

    private static bool[] DFS_FromNode(int[,] matrix, int start)
    {
        int n = matrix.GetLength(0);
        var visited = new bool[n];
        var stack = new Stack<int>();

        visited[start] = true;
        stack.Push(start);

        while (stack.Count > 0)
        {
            int current = stack.Pop();
            for (int i = 0; i < n; i++)
            {
                if (matrix[current, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    stack.Push(i);
                }
            }
        }

        return visited;
    }

    private static void PrintReachabilityMatrix(int[,] reachabilityMatrix, Graph graph)
    {
        var vertices  = graph.Vertices;
        Console.Write("   ");
        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            Console.Write($"{vertices[i].Name} ");
        }
        Console.WriteLine();
        
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