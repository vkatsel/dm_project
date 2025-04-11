using dm_project.DataStructures;

namespace dm_project;

public class GraphGenerator
{
    public static Graph GenerateRandomGraph(int vertexCount, double density)
    {
        if (density < 0 || density > 1)
            throw new ArgumentException("Density must be between 0 and 1.");

        var vertices = new List<Vertex>();
        var edges = new List<Edge>();

        for (int i = 0; i < vertexCount; i++)
        {
            vertices.Add(new Vertex($"V{i}"));
        }

        int maxEdges = vertexCount * (vertexCount - 1) / 2;
        int targetEdgeCount = (int)(density * maxEdges);

        var random = new Random();
        var edgeSet = new HashSet<(int, int)>();

        while (edges.Count < targetEdgeCount)
        {
            int a = random.Next(vertexCount);
            int b = random.Next(vertexCount);

            if (a == b) continue;

            int i = Math.Min(a, b);
            int j = Math.Max(a, b);

            if (!edgeSet.Contains((i, j)))
            {
                edgeSet.Add((i, j));
                var edge = new Edge(vertices[i], vertices[j]);
                edges.Add(edge);
            }
        }

        var graph = new Graph(vertices, new List<Edge>());
        foreach (var edge in edges)
        {
            graph.AddEdge(edge);
        }

        return graph;
    }
}