namespace dm_project.DataStructures;

public class Edge
{
    public Vertex VertA { get; set; }
    public Vertex VertB { get; set; }
    public float Weight { get; set; }

    public Edge(Vertex vertA, Vertex vertB)
    {
        VertA = vertA;
        VertB = vertB;
    }
   
}