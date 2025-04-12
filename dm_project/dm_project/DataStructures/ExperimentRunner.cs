using System.Diagnostics;
using System.Globalization;
using System.IO;
using dm_project.DataStructures;

namespace dm_project;

public static class ExperimentRunner
{
    public static void Run()
    {
        var sizes = new[] { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
        var densities = new[] { 0.1, 0.3, 0.5, 0.7, 0.9 };
        int runsPerCase = 20;

        bool fileExists = File.Exists("results.csv");

        using var writer = new StreamWriter("results.csv", append: true);

        if (!fileExists)
        {
            writer.WriteLine("size,density,algorithm,representation,time_ms");
        }

        foreach (var size in sizes)
        {
            foreach (var density in densities)
            {
                for (int run = 0; run < runsPerCase; run++)
                {
                    var graph = GraphGenerator.GenerateRandomGraph(size, density);

                    var sw = Stopwatch.StartNew();

                    ReachabilityMatrix.BFS_Build(graph);
                    sw.Stop();
                    writer.WriteLine($"{size.ToString(CultureInfo.InvariantCulture)},{density},{nameof(ReachabilityMatrix.BFS_Build)},list,{sw.ElapsedMilliseconds}");

                    sw.Restart();
                    ReachabilityMatrix.DFS_Build(graph);
                    sw.Stop();
                    writer.WriteLine($"{size},{density},{nameof(ReachabilityMatrix.DFS_Build)},list,{sw.ElapsedMilliseconds}");

                    sw.Restart();
                    ReachabilityMatrix.BFS_Build_Matrix(graph);
                    sw.Stop();
                    writer.WriteLine($"{size},{density},{nameof(ReachabilityMatrix.BFS_Build_Matrix)},matrix,{sw.ElapsedMilliseconds}");

                    var adjMatrix = graph.BuildAdjacencyMatrix();
                    sw.Restart();
                    ReachabilityMatrix.DFS_Build_AdjMatrix(graph, adjMatrix);
                    sw.Stop();
                    writer.WriteLine($"{size},{density},{nameof(ReachabilityMatrix.DFS_Build_AdjMatrix)},matrix,{sw.ElapsedMilliseconds}");
                }

                Console.WriteLine($"Done: size = {size}, density = {density}");
            }
        }

        Console.WriteLine("All experiments finished. Results appended to results.csv.");
    }
}
 