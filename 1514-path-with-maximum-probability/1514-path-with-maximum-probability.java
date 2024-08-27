class Solution {
    public double maxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
        var graph = buildGraph(n, edges, succProb);
        if(graph[start_node].size() == 0 || graph[end_node].size() == 0) return 0.0;   // if it is not connected

        var visited = new boolean[n];
        visited[start_node] = true;

        var queue = new PriorityQueue<Edge>((e1, e2) -> Double.compare(e2.prob, e1.prob));
        for(var e : graph[start_node]) queue.offer(e);

        // BFS
        while(!queue.isEmpty()){
            var e = queue.poll();
            if(e.dest == end_node) return e.prob;
            visited[e.dest] = true;

            for(var ed : graph[e.dest]){
                if(visited[ed.dest]) continue;
                queue.offer(new Edge(ed.dest, ed.prob * e.prob));
            }
        }

        return 0.0;
    }

    private List<Edge>[] buildGraph(int n, int[][] edges, double[] succProb){
        List<Edge>[] graph = new ArrayList[n];
        for(var i=0; i<n; i++) graph[i] = new ArrayList<Edge>();

        for(var i=0; i<edges.length; i++){
            int src = edges[i][0], dest = edges[i][1];
            graph[src].add(new Edge(dest, succProb[i]));
            graph[dest].add(new Edge(src, succProb[i]));
        }

        return graph;
    }
}

class Edge {
    int dest;
    double prob;

    public Edge(int d, double p){
        dest = d;
        prob = p;
    }
}