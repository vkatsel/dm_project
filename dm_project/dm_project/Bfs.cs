using dm_project.DataStructures;

namespace dm_project;

public static class Bfs
{
    public static List<Vertex> Breadth_First_Search(Vertex a, Vertex b)
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
                return GetPath(a, current, parent);
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

        return new List<Vertex>();
    }

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