public class Solution {
    public int SecondMinimum(int n, int[][] edges, int cost, int change) {
        var graph = BuildGraph(n, edges);
        return BFS(graph, cost, change);
    }

    private int BFS(List<int>[] graph, int cost, int change){
        var n = graph.Length - 1;
        int[] dist1 = new int[n+1], dist2 = new int[n+1];
        for(var i=0; i<=n; i++)
            dist1[i] = dist2[i] = -1;

        var queue = new Queue<(int, int)>();
        queue.Enqueue((1, 1));
        dist1[1] = 0;

        while(queue.Count > 0){
            var (node, freq) = queue.Dequeue();
            if(graph[node].Count == 0) continue;

            var timeTaken = dist1[node];
            if(freq != 1) timeTaken = dist2[node];
            timeTaken = RedGreen(timeTaken, cost, change);

            foreach(var next in graph[node]){
                if(dist1[next] == -1){
                    dist1[next] = timeTaken;
                    queue.Enqueue((next, 1));
                }
                else if(dist2[next] == -1 && dist1[next] != timeTaken){
                    if(next == n) return timeTaken;
                    dist2[next] = timeTaken;
                    queue.Enqueue((next, 2));
                }
            }
        }

        return 0;   // this will actually never reach
    }

    private int RedGreen(int timeTaken, int cost, int change){
        if((timeTaken / change) % 2 == 0)
            return timeTaken + cost;
        var timeTakenDueToSignal = change * (timeTaken / change + 1);
        return cost + timeTakenDueToSignal;
    }

    private List<int>[] BuildGraph(int n, int[][] edges){
        var adjList = new List<int>[n+1];
        for(var i=0; i<=n; i++) 
            adjList[i] = new();

        foreach(var edge in edges){
            int src = edge[0], dest = edge[1];
            adjList[src].Add(dest);
            adjList[dest].Add(src);
        }

        return adjList;
    }
}