namespace dm_project.DataStructures;

public class Edge(Vertex vertA, Vertex vertB, float weight)
{
    public Vertex VertA { get; set; } = vertA;
    public Vertex VertB { get; set; } = vertB;
    public float Weight { get; set; } = weight;
}