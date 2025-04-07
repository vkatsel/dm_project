// namespace dm_project;
//
// /* Adjacency List */
// public class GraphAL
// {
//     private int verticesCount;
//     private ArrayList<int>[] adjacencyList;
//
//     public GraphAL(int v)
//     {
//         verticesCount = v;
//         adjacencyList = new ArrayList<int>[verticesCount];
//
//         for (int i = 0; i < verticesCount; i++)
//         {
//             adjacencyList[i] = new ArrayList<int>();
//         }
//     }
//
//     public void AddEdge(int v, int u)
//     {
//         adjacencyList[v].PushBack(u);
//     }
//
//     public void DFS(int v)
//     {
//         bool[] visited = new bool[verticesCount];
//         Stack stack = new Stack(verticesCount);
//
//         stack.Push(v);
//
//         while (stack.Size() > 0)
//         {
//             int vertex = stack.Pop();
//
//             if (!visited[vertex])
//             {
//                 Console.Write($"{vertex} ->");
//                 visited[vertex] = true;
//             }
//
//             ArrayList<int> neighbors = adjacencyList[vertex];
//
//             for (int i = 0; i < neighbors.Size(); i++)
//             {
//                 int neighbor = neighbors.GetAt(i);
//
//                 if (!visited[neighbor])
//                 {
//                     stack.Push(neighbor);
//                 }
//             }
//         }
//
//         Console.WriteLine();
//     }
//
//     public void DFSUtil(int v, bool[] visited)
//     {
//
//         if (!visited[v])
//         {
//             Console.Write($"{v} ->");
//             visited[v] = true;
//         }
//
//         ArrayList<int> neighbors = adjacencyList[v];
//
//         for (int i = 0; i < neighbors.Size(); i++)
//         {
//             int neighbor = neighbors.GetAt(i);
//
//             if (!visited[neighbor])
//             {
//                 DFSUtil(neighbor, visited);
//             }
//         }
//     }
//
//     public void DFSRecursive(int v) {
//         bool[] visited = new bool[verticesCount];
//
//         DFSUtil(v, visited);
//
//         Console.WriteLine();
//     }
//
//     public void BFS(int v) {
//         bool[] visited = new bool[verticesCount];
//         Queue queue = new Queue(verticesCount);
//
//         queue.Enqueue(v);
//         visited[v] = true;
//
//         while(queue.Size() > 0) {
//             int vertex = queue.Dequeue();
//             
//             Console.Write($"{ vertex } -> ");
//             
//             ArrayList<int> neighbors = adjacencyList[vertex];
//
//             for (int i = 0; i < neighbors.Size(); i++) {
//                 int neighbor = neighbors.GetAt(i);
//     
//                 if (!visited[neighbor]) {
//                     queue.Enqueue(neighbor);
//                     visited[neighbor] = true;
//                 }
//             } 
//         }
//
//         Console.WriteLine();
//
//     }
//
//     public void Print()
//     {
//         for (int i = 0; i < verticesCount; i++)
//         {
//             Console.Write($"{i} -> ");
//
//             for (int j = 0; j < adjacencyList[i].Size(); j++)
//             {
//                 Console.Write($"{adjacencyList[i].GetAt(j)} ");
//             }
//
//             Console.WriteLine();
//         }
//         Console.WriteLine();
//     }
// }