public class Solution {
    public bool[] FindAnswer(int n, int[][] edges) {
        var graph = EdgesToGraph(n, edges);
        var shortestPathEdges = Dijkstra(graph);
        
        // now check which edges are part of the shortest path
        var ans = new bool[edges.Length];
        for(var i=0; i<edges.Length; i++){
            var (s,d,w) = (edges[i][0], edges[i][1], edges[i][2]);
            if(shortestPathEdges.Contains((s, d)) || shortestPathEdges.Contains((d, s)))
                ans[i] = true;
        }
        
        return ans;
    }

    // function to covert edges to adjacency list
    private List<(int, int)>[] EdgesToGraph(int n, int[][] edges){
        var graph = new List<(int, int)>[n];
        for(var i=0; i<n; i++) graph[i] = new List<(int, int)>();

        foreach(var edge in edges){
            var (s, d, w) = (edge[0], edge[1], edge[2]);
            graph[s].Add((d, w));
            graph[d].Add((s, w));
        }

        return graph;
    }

    // function to find shortest distance to reach each node
    private HashSet<(int, int)> Dijkstra(List<(int, int)>[] graph) {
        var n = graph.Length;
        
        // shortest distance to reach each node
        var shortestDist = new int[n];
        Array.Fill(shortestDist, int.MaxValue);
        shortestDist[0] = 0;    // can reach node 0 in 0 distance, because we start from there

        var pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((0, 0), 0); // Starting from node 0 with distance 0

        // use Dijkstra to find shortest weight for reaching each node
        while (pq.Count > 0) {
            var (node, dist) = pq.Dequeue();

            if(dist > shortestDist[node]) continue;
            foreach (var (neighbor, weight) in graph[node]) {
                if(shortestDist[node] + weight >= shortestDist[neighbor]) continue;
                shortestDist[neighbor] = shortestDist[node] + weight;
                pq.Enqueue((neighbor, shortestDist[neighbor]), shortestDist[neighbor]);
            }
        }

        // starting from last node, find the shortest routes to reach node 0
        var shortestPathEdges = new HashSet<(int, int)>();
        var queue = new Queue<int>();
        queue.Enqueue(n-1);
        while(queue.Count > 0){
            var node = queue.Dequeue();
            foreach (var (neighbor, weight) in graph[node]) {
                if(shortestDist[node] - weight == shortestDist[neighbor]){
                    shortestPathEdges.Add((node, neighbor));
                    queue.Enqueue(neighbor);
                }
            }
        }

        return shortestPathEdges;
    }
}