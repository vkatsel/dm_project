using dm_project.DataStructures;

namespace dm_project;

public static class BFS
{
    //Woking with Adj
    public static (List<Vertex>, bool) Breadth_First_Search(Vertex a, Vertex b)
    {
        var queue = new Queue<Vertex>();
        
        var visited = new HashSet<Vertex>();
        var parent = new Dictionary<Vertex, Vertex>();
        var distance = new Dictionary<Vertex, int>();
        
        visited.Add(a);
        queue.Enqueue(a);
        distance[a] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (b.Equals(current))
            {
                return (GetPath(a, current, parent), true);
            }
                
            foreach (var adjacentVertex in current.AdjacentVertices)
            {
                if (!visited.Contains(adjacentVertex))
                {
                    parent[adjacentVertex] = current;
                    distance[adjacentVertex] = distance[current] + 1;
                    visited.Add(adjacentVertex);
                    queue.Enqueue(adjacentVertex);
                }
            }
        }

        return (new List<Vertex>(), false);
    }
    //
    
    //Working with Matrix
    public static bool BFS_Matrix(int[,] matrix, int start, int target)
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

    //Not necesarily needed, working with Breadth_First_Search
    private static List<Vertex> GetPath(Vertex a, Vertex current, Dictionary<Vertex, Vertex> parent)
    {
        var path = new List<Vertex>();
        while (!current.Equals(a))
        {
            path.Add(current);
            current = parent[current];
        }
        path.Add(current);
        path.Reverse();
        return path;
    }
    
    
}