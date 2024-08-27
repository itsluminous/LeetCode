public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
        var graph = BuildGraph(n, edges, succProb);
        if(graph[start_node].Count == 0 || graph[end_node].Count == 0) return 0.0;   // if it is not connected

        var visited = new bool[n];
        visited[start_node] = true;

        var queue = new PriorityQueue<Edge, double>();
        foreach(var e in graph[start_node]) queue.Enqueue(e, -e.prob);

        // BFS
        while(queue.Count > 0){
            var e = queue.Dequeue();
            if(e.dest == end_node) return e.prob;
            visited[e.dest] = true;

            foreach(var ed in graph[e.dest]){
                if(visited[ed.dest]) continue;
                var newEdge = new Edge(ed.dest, ed.prob * e.prob);
                queue.Enqueue(newEdge, -newEdge.prob);
            }
        }

        return 0.0;
    }

    private List<Edge>[] BuildGraph(int n, int[][] edges, double[] succProb){
        var graph = new List<Edge>[n];
        for(var i=0; i<n; i++) graph[i] = new List<Edge>();

        for(var i=0; i<edges.Length; i++){
            int src = edges[i][0], dest = edges[i][1];
            graph[src].Add(new Edge(dest, succProb[i]));
            graph[dest].Add(new Edge(src, succProb[i]));
        }

        return graph;
    }
}

class Edge {
    public int dest;
    public double prob;

    public Edge(int d, double p){
        dest = d;
        prob = p;
    }
}