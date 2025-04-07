namespace dm_project.DataStructures;

public class Vertex(string name)
{
    public string Name { get; set; } = name;
    public HashSet<Vertex> AdjacentVertices { get; } = new HashSet<Vertex>();
}