using dm_project.DataStructures;

namespace dm_project;

public class Graph(List<Vertex> vertices, List<Edge> edges)
{
    public List<Vertex> Vertices = vertices;
    public List<Edge> Edges = edges;

    public void AddVertex(Vertex vertex)
    {
        Vertices.Add(vertex);
    }

    public void RemoveVertex(Vertex vertex)
    {
        Edges.RemoveAll(edge => edge.VertA == vertex || edge.VertB == vertex);
        Vertices.Remove(vertex);
    }

    public void AddEdge(Edge edge)
    {
        Edges.Add(edge);
        if (!edge.VertA.AdjacentVertices.Contains(edge.VertB))
        {
            edge.VertA.AdjacentVertices.Add(edge.VertB);
        }
        if (!edge.VertB.AdjacentVertices.Contains(edge.VertA))
        {
            edge.VertB.AdjacentVertices.Add(edge.VertA);
        }
    }

    public void RemoveEdge(Edge edge)
    {
        throw new NotImplementedException();
    }

    public List<List<bool>> BuildAdjacencyMatrix()
    {
        throw new NotImplementedException();
    }

    public Dictionary<Vertex, HashSet<Vertex>> BuildAdjacencyLists()
    {
        var adjacencyList = new Dictionary<Vertex, HashSet<Vertex>>();
        foreach (var vertex in Vertices)
        {
            foreach (var edge in Edges)
            {
                if (edge.VertA.Name == vertex.Name)
                {
                    vertex.AdjacentVertices.Add(edge.VertB);
                }
                else if (edge.VertB.Name == vertex.Name)
                {
                    vertex.AdjacentVertices.Add(edge.VertA);
                }
            }
            adjacencyList.Add(vertex, vertex.AdjacentVertices.ToHashSet());
        }
        return adjacencyList;
    }
    
}