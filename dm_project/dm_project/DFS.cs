using dm_project.DataStructures;

namespace dm_project;

public static class DFS
{
    public static (List<Vertex>, bool) Depth_First_Search(Vertex a, Vertex b)
    {
        var visited = new HashSet<Vertex>();
        var parent = new Dictionary<Vertex, Vertex>();

        bool found = DFS_Helper(a, b, visited, parent);

        if (!found)
            return (new List<Vertex>(), false);

        return (GetPath(a, b, parent), true);
    }

    private static bool DFS_Helper(Vertex current, Vertex target, HashSet<Vertex> visited, Dictionary<Vertex, Vertex> parent)
    {
        visited.Add(current);

        if (current.Equals(target))
            return true;

        foreach (var neighbor in current.AdjacentVertices)
        {
            if (!visited.Contains(neighbor))
            {
                parent[neighbor] = current;

                if (DFS_Helper(neighbor, target, visited, parent))
                    return true;
            }
        }

        return false;
    }

    private static List<Vertex> GetPath(Vertex start, Vertex end, Dictionary<Vertex, Vertex> parent)
    {
        var path = new List<Vertex>();
        var current = end;

        while (!current.Equals(start))
        {
            path.Add(current);
            current = parent[current];
        }

        path.Add(start);
        path.Reverse();
        return path;
    }
}
