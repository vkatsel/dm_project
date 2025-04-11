using dm_project.DataStructures;

namespace dm_project;

class Program
{
    static void Main(string[] args)
    {
        var vertices = new List<Vertex>();
        var edges = new List<Edge>();
        var graph = new Graph(vertices, edges);
        
        var vertexA = new Vertex("A");
        var vertexB = new Vertex("B");
        var vertexC = new Vertex("C");
        var vertexD = new Vertex("D");
        var edgeAB = new Edge(vertexA, vertexB);
        var edgeAC = new Edge(vertexA, vertexC);
        vertices.Add(vertexA);
        vertices.Add(vertexB);
        vertices.Add(vertexC);
        vertices.Add(vertexD);
        edges.Add(edgeAB);
        edges.Add(edgeAC);
        var adjacencyList = graph.BuildAdjacencyLists();
        var adjacencyMatrix = graph.BuildAdjacencyMatrix();
        for (int i = 0; i < graph.Vertices.Count; i++)
        {
            for (int j = 0; j < graph.Vertices.Count; j++)
            {
                Console.Write(adjacencyMatrix[i, j]);
            }
            Console.WriteLine();
        }
        ReachabilityMatrix.BFS_Build(graph);
        ReachabilityMatrix.DFS_Build_AdjMatrix(graph, adjacencyMatrix);
        
        //ToDo: Do DFS via adjacency matrix
        //ToDo: Do BFS via adjacency matrix
    }
    
    
}