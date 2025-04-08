namespace dm_project.DataStructures;

public class Vertex(string name)
{
    public string Name { get; set; } = name;
    public HashSet<Vertex> AdjacentVertices { get; } = new HashSet<Vertex>();
    
    public override bool Equals(object? obj)
    {
        if (obj is not Vertex other)
            return false;

        return Name.Equals(other.Name) && AdjacentVertices.SetEquals(AdjacentVertices);
    }
}